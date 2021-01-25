using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UINavigationButton : UIComponent, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {
	public Sprite Icon;
	public string Label;
	public float TransitionSpeed = 0.125f;
	public UnityEvent OnClick = new UnityEvent();

	[AutoRef("ICON")] private Image iconImageRef;
	[AutoRef("BG")] private Image backgroundImageRef;
	[AutoRef("BG")] private Shadow shadowRef;
	[AutoRef("MASK/TEXT")] private TextMeshProUGUI labelRef;

	private bool isHovering;
	private bool isPressed;
	private bool isLocked;

	public override void AutoUI() {
		labelRef.text = Label;
		iconImageRef.sprite = Icon;
	}

	private void HoverState() {
		iconImageRef.DOColor(ColorPalette.Yellow, TransitionSpeed);
		labelRef.DOColor(ColorPalette.Yellow, TransitionSpeed);
		backgroundImageRef.DOColor(ColorPalette.DarkBlue, TransitionSpeed);
		DOTween.To(() => shadowRef.effectColor, value => shadowRef.effectColor = value, new Color(0, 0, 0, 0.18f), TransitionSpeed);
	}

	private void NormalState() {
		iconImageRef.DOColor(ColorPalette.Yellow75, TransitionSpeed);
		labelRef.DOColor(ColorPalette.Yellow75, TransitionSpeed);
		backgroundImageRef.DOColor(ColorPalette.DarkBlue, TransitionSpeed);
		DOTween.To(() => shadowRef.effectColor, value => shadowRef.effectColor = value, new Color(0, 0, 0, 0), TransitionSpeed);
	}

	private void ActiveState() {
		iconImageRef.DOColor(ColorPalette.Yellow, TransitionSpeed);
		labelRef.DOColor(ColorPalette.Yellow, TransitionSpeed);
		backgroundImageRef.DOColor(ColorPalette.Dark, TransitionSpeed);
		DOTween.To(() => shadowRef.effectColor, value => shadowRef.effectColor = value, new Color(0, 0, 0, 0.18f), TransitionSpeed);
	}

	private void HoverStateImmediate() {
		iconImageRef.color = ColorPalette.Yellow;
		labelRef.color = ColorPalette.Yellow;
		backgroundImageRef.color = ColorPalette.DarkBlue;
		shadowRef.effectColor = new Color(0, 0, 0, 0.18f);
	}

	private void NormalStateImmediate() {
		iconImageRef.color = ColorPalette.Yellow75;
		labelRef.color = ColorPalette.Yellow75;
		backgroundImageRef.color = ColorPalette.DarkBlue;
		shadowRef.effectColor = new Color(0, 0, 0, 0);
	}

	private void ActiveStateImmediate() {
		iconImageRef.color = ColorPalette.Yellow;
		labelRef.color = ColorPalette.Yellow;
		backgroundImageRef.color = ColorPalette.Dark;
		shadowRef.effectColor = new Color(0, 0, 0, 0.18f);
	}

	public void SetLock(bool locked) {
		isLocked = locked;
		if (isLocked) {
			iconImageRef.DOKill();
			labelRef.DOKill();
			backgroundImageRef.DOKill();
			shadowRef.DOKill();
			ActiveStateImmediate();
		} else {
			if (isPressed) ActiveStateImmediate();
			else if (isHovering) HoverStateImmediate();
			else NormalStateImmediate();
		}
	}

	public void OnPointerEnter(PointerEventData eventData) {
		isHovering = true;
		if (!isPressed && !isLocked) HoverState();
	}

	public void OnPointerExit(PointerEventData eventData) {
		isHovering = false;
		if (!isPressed && !isLocked) NormalState();
	}

	public void OnPointerDown(PointerEventData eventData) {
		isPressed = true;
		if (!isLocked) ActiveState();
	}

	public void OnPointerUp(PointerEventData eventData) {
		isPressed = false;
		if (!isLocked) {
			if (isHovering) HoverState();
			else NormalState();
		}
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (!isLocked) OnClick?.Invoke();
	}
}