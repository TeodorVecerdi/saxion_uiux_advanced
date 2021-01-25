using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UITile))]
public class UITileDrawer : AutoUIDrawer<UITile> {
	private static GameObject prefabNormal;
	private static GameObject prefabButton;
	
	[MenuItem("GameObject/UI/UITile", false, 0)]
	public static void InstantiatePrefab() {
		if(prefabNormal == null) prefabNormal = Resources.Load<GameObject>("Prefabs/Components/Tile");
		MakePrefab(prefabNormal);
	}
	
	[MenuItem("GameObject/UI/UITile Button", false, 0)]
	public static void InstantiatePrefabButton() {
		if(prefabButton == null) prefabButton = Resources.Load<GameObject>("Prefabs/Components/Clickable Tile");
		MakePrefab(prefabButton);
	}
	
	
}