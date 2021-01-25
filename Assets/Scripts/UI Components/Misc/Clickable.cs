using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ManualRef]
public class Clickable: UIComponent, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {
	public float TransitionSpeed = 0.125f;
	public UnityEvent OnClick = new UnityEvent();
	public string BackgroundPath = "";
	public string ShadowPath = "";
	[Space]
	public Color NormalColor = ColorPalette.DarkBlue;
	public Color HoverColor = ColorPalette.DarkBlue;
	public Color ActiveColor = ColorPalette.Dark;

	private Image backgroundRef;
	private Shadow shadowRef;
	
	private bool isHovering;
	private bool isPressed;

	public override void AutoUI() {
	}

	protected override void GetReferences() {
		if (backgroundRef == null) backgroundRef = transform.GetComponentRecursive<Image>(BackgroundPath);
		if (shadowRef == null) shadowRef = transform.GetComponentRecursive<Shadow>(ShadowPath);
	}

	protected override void ForceGetReferences() {
		backgroundRef = transform.GetComponentRecursive<Image>(BackgroundPath);
		shadowRef = transform.GetComponentRecursive<Shadow>(ShadowPath);
	}

	protected override void Start() {
		base.Start();
		NormalState();
	}
	
	private void HoverState() {
		if (backgroundRef != null) backgroundRef.DOColor(HoverColor, TransitionSpeed);
		if (shadowRef != null) DOTween.To(() => shadowRef.effectColor, value => shadowRef.effectColor = value, new Color(0, 0, 0, 0.18f), TransitionSpeed);
	}

	private void NormalState() {
		if (backgroundRef != null) backgroundRef.DOColor(NormalColor, TransitionSpeed);
		if (shadowRef != null) DOTween.To(() => shadowRef.effectColor, value => shadowRef.effectColor = value, new Color(0, 0, 0, 0), TransitionSpeed);
	}

	private void ActiveState() {
		if (backgroundRef != null) backgroundRef.DOColor(ActiveColor, TransitionSpeed);
		if (shadowRef != null) DOTween.To(() => shadowRef.effectColor, value => shadowRef.effectColor = value, new Color(0, 0, 0, 0.18f), TransitionSpeed);
	}

	public void OnPointerEnter(PointerEventData eventData) {
		isHovering = true;
		if(!isPressed) HoverState();
	}

	public void OnPointerExit(PointerEventData eventData) {
		isHovering = false;
		if(!isPressed) NormalState();
	}

	public void OnPointerDown(PointerEventData eventData) {
		isPressed = true;
		ActiveState();
	}

	public void OnPointerUp(PointerEventData eventData) {
		isPressed = false;
		if(isHovering) HoverState();
		else NormalState();
	}

	public void OnPointerClick(PointerEventData eventData) {
		OnClick?.Invoke();
	}
}