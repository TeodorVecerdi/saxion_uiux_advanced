using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICheckbox : UIComponent, IPointerClickHandler {
	public string Label = "Label";
	public bool Checked;
	public float TransitionSpeed = 0.125f;
	
	[AutoRef("BG/ICON")] private Image checkImageRef;
	[AutoRef("BG/LABEL")] private TextMeshProUGUI textRef;

	[AutoRef("Icons/CheckboxChecked", true)] private Sprite checkedSprite;
	[AutoRef("Icons/CheckboxUnchecked", true)] private Sprite uncheckedSprite;
	
	public override void AutoUI() {
		checkImageRef.sprite = Checked ? checkedSprite : uncheckedSprite;
		checkImageRef.color = Checked ? ColorPalette.Green : ColorPalette.Green75;
		textRef.color = Checked ? ColorPalette.Yellow : ColorPalette.Yellow75;
		textRef.text = Label;
	}

	public void CheckedState() {
		checkImageRef.sprite = checkedSprite;
		checkImageRef.DOColor(ColorPalette.Green, TransitionSpeed);
		textRef.DOColor(ColorPalette.Yellow, TransitionSpeed);
	}

	public void UncheckedState() {
		checkImageRef.sprite = uncheckedSprite;
		checkImageRef.DOColor(ColorPalette.Green75, TransitionSpeed);
		textRef.DOColor(ColorPalette.Yellow75, TransitionSpeed);
	}

	public void OnPointerClick(PointerEventData eventData) {
		Checked = !Checked;
		if (Checked) CheckedState();
		else UncheckedState();
	}
}