using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class UIInputField : UIComponent {
	[SerializeField] public string Label = "Label";
	[SerializeField] public string Placeholder = "Placeholder";
	[SerializeField] public string Text;
	[SerializeField] public bool DisplayLabel = true;
	[Space]
	[SerializeField] public bool IsPassword = false;
	[SerializeField] public char PasswordChar = '•';
	[Space]
	[AutoRef("INPUT")] private TMP_InputField inputFieldRef;
	[AutoRef("LABEL")] private TextMeshProUGUI labelRef;
	[AutoRef("INPUT/TEXTAREA/PLACEHOLDER")] private TextMeshProUGUI placeholderRef;

	public override void AutoUI() {
		labelRef.text = Label;
		placeholderRef.text = Placeholder;
		labelRef.gameObject.SetActive(DisplayLabel);
		inputFieldRef.text = Text;
		inputFieldRef.contentType = IsPassword ? TMP_InputField.ContentType.Password : TMP_InputField.ContentType.Standard;
		inputFieldRef.asteriskChar = PasswordChar;
		inputFieldRef.ForceLabelUpdate();
	}
}