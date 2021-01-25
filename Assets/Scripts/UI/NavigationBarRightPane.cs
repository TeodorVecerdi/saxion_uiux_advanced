using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class NavigationBarRightPane : MonoBehaviour, IPointerClickHandler {
	[HideInInspector] public RectTransform RectTransform;
	private NavigationBarController mainController;

	private void Awake() {
		RectTransform = GetComponent<RectTransform>();
		mainController = transform.GetComponentInParent<NavigationBarController>();
	}

	public void OnPointerClick(PointerEventData eventData) {
		mainController.Close();
	}
}