using System;
using TMPro;
using UnityEngine;

public class ChatMessage : MonoBehaviour {
	public RectTransform Self;
	public RectTransform Reference;
	public TextMeshProUGUI MessageText;
	public float ExtraPadding;
	public float MinHeight;

	public void Initialize(string message) {
		MessageText.SetText(message);
	}

	private void Update() {
		var size = Self.sizeDelta;
		size.y = Mathf.Max(Reference.sizeDelta.y + ExtraPadding, MinHeight);
		Self.sizeDelta = size;
	}
}