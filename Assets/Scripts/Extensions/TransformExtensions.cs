	using System;
	using UnityEngine;

	public static class TransformExtensions {
		public static Transform FindChildRecursive(this Transform transform, string path) {
			if (string.IsNullOrEmpty(path)) return transform;
			var pathSplit = path.Split('/');
			Transform currentTransform = transform;
			for (int i = 0; i < pathSplit.Length; i++) {
				if (currentTransform == null) return null;
				if (pathSplit[i] == "..") currentTransform = currentTransform.parent;
				else currentTransform = currentTransform.Find(pathSplit[i]);
			}

			return currentTransform;
		}

		public static T GetComponentRecursive<T>(this Transform transform, string path) where T : Component {
			if (string.IsNullOrEmpty(path)) return transform.GetComponent<T>();
			var componentTransform = FindChildRecursive(transform, path);
			return componentTransform switch {
				null => null,
				_ => componentTransform.GetComponent<T>()
			};
		}
		
		public static Component GetComponentRecursive(this Transform transform, string path, Type componentType)  {
			if (string.IsNullOrEmpty(path)) return transform.GetComponent(componentType);
			var componentTransform = FindChildRecursive(transform, path);
			return componentTransform switch {
				null => null,
				_ => componentTransform.GetComponent(componentType)
			};
		}
	}