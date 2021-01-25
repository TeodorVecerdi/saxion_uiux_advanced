using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UICourseEntry))]
public class UICourseEntryDrawer : AutoUIDrawer<UICourseEntry> {
	private static GameObject prefab;
	
	[MenuItem("GameObject/UI/UI Course Entry", false, 0)]
	public static void InstantiatePrefab() {
		if(prefab == null) prefab = Resources.Load<GameObject>("Prefabs/Input/UICourseEntry");
		MakePrefab(prefab);
	}
	
}