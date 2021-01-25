using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public abstract class UIComponent : MonoBehaviour {
	private List<(FieldInfo, AutoRefAttribute)> typeCache;
	private bool? manualReferencing = null;

	protected virtual void OnEnable() {
		ForceReference();
		AutoUI();
	}

	protected virtual void Start() {
		ForceReference();
		AutoUI();
	}

	public abstract void AutoUI();

	protected virtual void GetReferences() {
	}

	protected virtual void ForceGetReferences() {
	}

	public void ForceReference() {
		if (manualReferencing == null) {
			var type = GetType();
			manualReferencing = type.GetCustomAttribute<ManualRefAttribute>() != null;
		}

		if (manualReferencing.Value) {
			ForceGetReferences();
		}

		if (typeCache == null) {
			var type = GetType();
			typeCache = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
			                .Where(field => field.IsDefined(typeof(AutoRefAttribute)))
			                .Select(info => (info, info.GetCustomAttribute<AutoRefAttribute>())).ToList();
		}

		foreach (var (field, attribute) in typeCache) {
			if (!attribute.LoadResource) {
				var fieldType = field.FieldType;
				var path = attribute.BindingPath;
				if (attribute.GetGameObject) {
					var target = transform.FindChildRecursive(path).gameObject;
					if (target == null) Debug.LogWarning($"{name}.{field.Name} is null. Invalid path <b>{path}</b>");
					field.SetValue(this, target);
				} else {
					var component = transform.GetComponentRecursive(path, fieldType);
					if (component == null) Debug.LogWarning($"{name}.{field.Name} is null. Invalid path <b>{path}</b>");
					field.SetValue(this, component);
				}
			} else {
				var resource = Resources.Load(attribute.BindingPath, field.FieldType);
				if (resource == null) Debug.LogWarning($"{name}.{field.Name} is null. Invalid path <b>{attribute.BindingPath}</b>");
				field.SetValue(this, resource);
			}
		}
	}

	public void Reference() {
		if (manualReferencing == null) {
			var type = GetType();
			manualReferencing = type.GetCustomAttribute<ManualRefAttribute>() != null;
		}

		if (manualReferencing.Value) {
			GetReferences();
		}

		if (typeCache == null) {
			var type = GetType();
			typeCache = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
			                .Where(field => field.IsDefined(typeof(AutoRefAttribute)))
			                .Select(info => (info, info.GetCustomAttribute<AutoRefAttribute>())).ToList();
		}

		foreach (var (field, attribute) in typeCache) {
			if (field.GetValue(this) == null) continue;

			if (!attribute.LoadResource) {
				var fieldType = field.FieldType;
				var path = attribute.BindingPath;
				if (attribute.GetGameObject) {
					var target = transform.FindChildRecursive(path).gameObject;
					if (target == null) Debug.LogWarning($"{name}.{field.Name} is null. Invalid path <b>{path}</b>");
					field.SetValue(this, target);
				} else {
					var component = transform.GetComponentRecursive(path, fieldType);
					if (component == null) Debug.LogWarning($"{name}.{field.Name} is null. Invalid path <b>{path}</b>");
					field.SetValue(this, component);
				}
			} else {
				var resource = Resources.Load(attribute.BindingPath, field.FieldType);
				if (resource == null) Debug.LogWarning($"{name}.{field.Name} is null. Invalid path <b>{attribute.BindingPath}</b>");
				field.SetValue(this, resource);
			}
		}
	}
}