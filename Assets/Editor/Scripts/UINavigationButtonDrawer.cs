using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UINavigationButton))]
public class UINavigationButtonDrawer : AutoUIDrawer<UINavigationButton> {
	private static GameObject prefab;
	
	[MenuItem("GameObject/UI/UINavigationButton", false, 0)]
	public static void InstantiatePrefab() {
		if(prefab == null) prefab = Resources.Load<GameObject>("Prefabs/Input/NavigationButton");
		MakePrefab(prefab);
	}
}