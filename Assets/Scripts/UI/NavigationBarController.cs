using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavigationBarController : MonoBehaviour {
	public float ClosedSize = 96f;
	public float OpenedSize = 240f;
	public float TransitionDuration = 0.125f;
	
	public RectTransform BarRef;
	public NavigationBarRightPane RightRef;

	private UINavigationButton lockedButton;
	
	private bool isOpen;
	
	public void LockButton(UINavigationButton buttonToLock) {
		if(lockedButton != null) lockedButton.SetLock(false);
		lockedButton = buttonToLock;
		if(lockedButton != null) lockedButton.SetLock(true);
	}

	public void UnlockButton() {
		if(lockedButton != null) lockedButton.SetLock(false);
		lockedButton = null;
	}

	public void Close() {
		isOpen = false;
		BarRef.DOSizeDelta(new Vector2(ClosedSize, 0), TransitionDuration);
		RightRef.RectTransform.DOSizeDelta(new Vector2(-ClosedSize, 0), TransitionDuration);
		RightRef.gameObject.SetActive(false);
	}

	public void Open() {
		isOpen = true;
		BarRef.DOSizeDelta(new Vector2(OpenedSize, 0), TransitionDuration);
		RightRef.RectTransform.DOSizeDelta(new Vector2(-OpenedSize, 0), TransitionDuration);
		RightRef.gameObject.SetActive(true);
	}

	public void Toggle() {
		if(isOpen) Close();
		else Open();
	}
}
