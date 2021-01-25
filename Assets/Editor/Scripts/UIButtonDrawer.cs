using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIButton))]
public class UIButtonDrawer : AutoUIDrawer<UIButton> {
	private static GameObject prefab;
	
	[MenuItem("GameObject/UI/UIButton", false, 0)]
	public static void InstantiatePrefab() {
		if(prefab == null) prefab = Resources.Load<GameObject>("Prefabs/Input/Button");
		MakePrefab(prefab);
	}
	
}