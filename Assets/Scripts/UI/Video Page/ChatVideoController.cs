using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChatVideoController : MonoBehaviour {
	public RectTransform ChatTransform;
	public RectTransform VideoTransform;
	public Image ChatCollapseImage;
	[Space]
	public Sprite Collapsed;
	public Sprite Expanded;

	private bool isCollapsed;

	private void Collapse() {
		isCollapsed = true;
		ChatTransform.DOSizeDelta(Vector2.zero, 0.125f);
		VideoTransform.DOAnchorPosX(0, 0.125f);
		VideoTransform.DOSizeDelta(new Vector2(0, -64), 0.125f);
		ChatCollapseImage.sprite = Collapsed;
	}

	private void Expand() {
		isCollapsed = false;
		ChatTransform.DOSizeDelta(new Vector2(432, 0), 0.125f);
		VideoTransform.DOAnchorPosX(-232, 0.125f);
		VideoTransform.DOSizeDelta(new Vector2(-464, -64), 0.125f);
		ChatCollapseImage.sprite = Expanded;
	}

	public void Toggle() {
		if(isCollapsed) Expand();
		else Collapse();
	}
}