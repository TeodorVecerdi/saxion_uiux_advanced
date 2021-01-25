using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class VolumeController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public GameObject UnmutedReference;
	public GameObject MutedReference;
	public GameObject RaycastGraphic;
	public RectTransform VolumeSliderReference;
	
	private bool isMuted;

	private void Start() {
		MutedReference.SetActive(false);
		RaycastGraphic.SetActive(false);
	}

	public void SetVolume(float volume) {
		if (isMuted) Unmute();
		if (Mathf.Approximately(volume, 0.0f)) Mute();
	}

	public void Mute() {
		isMuted = true;
		MutedReference.SetActive(true);
		UnmutedReference.SetActive(false);
	}

	public void Unmute() {
		isMuted = false;
		MutedReference.SetActive(false);
		UnmutedReference.SetActive(true);
	}

	public void OnPointerEnter(PointerEventData eventData) {
		VolumeSliderReference.DOSizeDelta(new Vector2(0, 160), 0.125f);
		RaycastGraphic.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData) {
		VolumeSliderReference.DOSizeDelta(new Vector2(0, 0), 0.125f);
		RaycastGraphic.SetActive(false);
	}
}