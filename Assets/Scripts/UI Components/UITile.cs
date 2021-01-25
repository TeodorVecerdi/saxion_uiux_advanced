using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class UITile : UIComponent {
	public string Title = "Title";
	public CourseActivity CourseActivity;
	public bool IsLive;

	[AutoRef("CENTER/SCROLL/VIEWPORT/TITLE")]private TextMeshProUGUI titleRef;
	[AutoRef("CENTER/DESCRIPTION")]private TextMeshProUGUI descriptionRef;
	[AutoRef("ICON")]private Image iconRef;
	[AutoRef("")]private Timer timerRef;
	
	[AutoRef("Icons/Live", true)]private Sprite liveIcon;
	[AutoRef("Icons/Recording", true)]private Sprite recordingIcon;

	public void OpenActivity() {
		NavigableController.Instance.OpenActivity(CourseActivity, IsLive);
	}

	public override void AutoUI() {
		titleRef.text = Title;
		descriptionRef.text = CourseActivity.ClassName;
		iconRef.sprite = IsLive ? liveIcon : recordingIcon;
		timerRef.Time = CourseActivity.Duration;
		timerRef.IsFixed = !IsLive;
		timerRef.ForceReference();
		timerRef.AutoUI();
	}
}