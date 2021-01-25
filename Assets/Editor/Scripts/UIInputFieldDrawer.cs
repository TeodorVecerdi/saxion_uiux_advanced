using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIInputField))]
public class UIInputFieldDrawer : AutoUIDrawer<UIInputField> {
	private static GameObject prefab;

	[MenuItem("GameObject/UI/UIInputField", false, 0)]
	public static void InstantiatePrefab() {
		if (prefab == null) prefab = Resources.Load<GameObject>("Prefabs/Input/Input Field");
		MakePrefab(prefab);
	}
}