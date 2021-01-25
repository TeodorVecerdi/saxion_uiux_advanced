using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BChooser : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
	public Image TargetImage;
	public TextMeshProUGUI TargetText;

	public void OnPointerEnter(PointerEventData eventData) {
		TargetImage.DOColor(new Color(1, 1, 1, 1), 0.25f);
		TargetText.DOColor(new Color(1, 1, 1, 1), 0.25f);
	}

	public void OnPointerExit(PointerEventData eventData) {
		TargetImage.DOColor(new Color(1, 1, 1, 0), 0.25f);
		TargetText.DOColor(new Color(1, 1, 1, 0), 0.25f);
	}

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log("Chose B");
		SceneManager.LoadScene(2);
	}
}

