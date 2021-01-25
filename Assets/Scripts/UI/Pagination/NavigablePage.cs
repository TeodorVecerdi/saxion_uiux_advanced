using System;
using DG.Tweening;
using UnityEngine;

public abstract class NavigablePage : MonoBehaviour {
	public virtual void Open() {
		gameObject.SetActive(true);
	}

	public virtual void Close() {
		DOTween.KillAll();
		gameObject.SetActive(false);
	}
}