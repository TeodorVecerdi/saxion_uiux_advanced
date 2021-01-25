using UnityEditor;
using UnityEngine;

public abstract class AutoUIDrawer<T> : Editor where T : UIComponent {
	public static void MakePrefab(GameObject prefab) {
		if (prefab == null) {
			Debug.LogError("Attempting to instantiate a null prefab. Make sure your path is valid.");
			return;
		}
		
		var instance = (Selection.activeTransform == null ? PrefabUtility.InstantiatePrefab(prefab) : PrefabUtility.InstantiatePrefab(prefab, Selection.activeTransform)) as GameObject;
		var autoUIComponentsChildren = instance.GetComponentsInChildren<UIComponent>();
		
		foreach (var autoUI in autoUIComponentsChildren) {
			autoUI.ForceReference();
			autoUI.AutoUI();
		}

		Selection.activeObject = instance;
	}

	public override void OnInspectorGUI() {
		EditorGUI.BeginChangeCheck();
		base.OnInspectorGUI();
		if (EditorGUI.EndChangeCheck() && !Application.isPlaying) {
			if (!(target is UIComponent autoUI)) return;
			autoUI.Reference();
			autoUI.AutoUI();
		}
	}
}