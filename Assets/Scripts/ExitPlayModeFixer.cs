using System;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class ExitPlayModeFixer : MonoBehaviour {
	private void OnEnable() {
		if (!Application.isPlaying) {
			foreach (var autoUI in FindObjectsOfType<MonoBehaviour>().OfType<UIComponent>()) {
				autoUI.ForceReference();
				autoUI.AutoUI();
			}
		}
	}
}