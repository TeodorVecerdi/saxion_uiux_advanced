using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UICheckbox))]
public class UICheckboxDrawer : AutoUIDrawer<UICheckbox> {
	private static GameObject prefab;
	
	[MenuItem("GameObject/UI/UICheckbox", false, 0)]
	public static void InstantiatePrefab() {
		if(prefab == null) prefab = Resources.Load<GameObject>("Prefabs/Input/Checkbox");
		MakePrefab(prefab);
	}
	
}