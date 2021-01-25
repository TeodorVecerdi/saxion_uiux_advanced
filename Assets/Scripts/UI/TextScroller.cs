using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScroller : MonoBehaviour {
    public float WaitTimeEnd = 2f;
    public float WaitTimeStart = 2f;
    public float ScrollDurationPerChar = 0.05f;
    public string ScrollRectPath = "";
    public string TextPath = "";
    
    private ScrollRect scrollRect;
    private TextMeshProUGUI textRef;
    public TweenerCore<float, float, FloatOptions> Tweener;

    private void Awake() {
        scrollRect = transform.GetComponentRecursive<ScrollRect>(ScrollRectPath);
        textRef = transform.GetComponentRecursive<TextMeshProUGUI>(TextPath);
    }

    private void Start() {
        InitScrolling();
    }

    public void InitScrolling() {
        Tweener?.Kill();
        StopAllCoroutines();
        scrollRect.horizontalNormalizedPosition = 0;
        StartCoroutine(Waiter());
    }

    private void ScrollRight() {
        Tweener = DOTween.To(() => scrollRect.horizontalNormalizedPosition, value => scrollRect.horizontalNormalizedPosition = value, 1.0f, textRef.text.Length * ScrollDurationPerChar);
        Tweener.SetEase(Ease.Linear);
        Tweener.OnComplete(() => StartCoroutine(Waiter()));
    }

    private IEnumerator Waiter() {
        yield return new WaitForSeconds(WaitTimeEnd);
        scrollRect.horizontalNormalizedPosition = 0;
        yield return new WaitForSeconds(WaitTimeStart);
        ScrollRight();
    }

}
