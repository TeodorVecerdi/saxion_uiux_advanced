using System;

[AttributeUsage(AttributeTargets.Field)]
public class AutoRefAttribute : Attribute {
	public string BindingPath;
	public bool LoadResource;
	public bool GetGameObject;

	public AutoRefAttribute(string bindingPath, bool loadResource = false, bool getGameObject = false) {
		BindingPath = bindingPath;
		LoadResource = loadResource;
		GetGameObject = getGameObject;
	}
}