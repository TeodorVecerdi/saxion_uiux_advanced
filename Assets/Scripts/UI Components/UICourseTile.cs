using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class UICourseTile : UIComponent {
	public CourseActivity CourseActivity;

	[AutoRef("CENTER/SCROLL/VIEWPORT/TITLE")] private TextMeshProUGUI titleRef;
	[AutoRef("")] private Timer timerRef;
	
	public void OpenActivity() {
		NavigableController.Instance.OpenActivity(CourseActivity, !timerRef.IsFixed);
	}

	public override void AutoUI() {
		titleRef.text = CourseActivity.ClassName;
		timerRef.Time = CourseActivity.Duration;
		timerRef.ForceReference();
		timerRef.AutoUI();
	}
}