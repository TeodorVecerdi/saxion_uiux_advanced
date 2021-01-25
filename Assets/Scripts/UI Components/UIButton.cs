using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class UIButton : UIComponent {
	[SerializeField] public string Label = "Label";
	[SerializeField] public Sprite Sprite;
	[SerializeField] public Image.Type SpriteType = Image.Type.Sliced;
	[SerializeField, Min(0.01f)] public float BorderRadius = 1;
	
	[AutoRef("BTN")] private Image buttonImageRef;
	[AutoRef("BTN/LABEL")] private TextMeshProUGUI labelRef;


	public override void AutoUI() {
		buttonImageRef.sprite = Sprite;
		buttonImageRef.type = SpriteType;
		if (SpriteType == Image.Type.Sliced)
			buttonImageRef.pixelsPerUnitMultiplier = BorderRadius;
		labelRef.text = Label;
	}
}