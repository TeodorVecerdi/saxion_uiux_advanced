using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlayerPage : NavigablePage {
	public TextMeshProUGUI CourseTitleText;
	public RecordingController RecordingController;
	public LiveController LiveController;

	private bool isLive;

	public override void Open() {
		base.Open();
	}
	
	public override void Close() {
		base.Close();
	}
	
	public void ToggleFullscreen() {
		if (isLive) {
			LiveController.gameObject.GetComponent<ChatVideoController>().Toggle();
		} else {
			RecordingController.gameObject.GetComponent<ChatVideoController>().Toggle();
		}
	}

	public void LoadVideo(CourseActivity activity, bool isLive) {
		this.isLive = isLive;
		CourseTitleText.text = activity.ClassName;
		if (isLive) {
			RecordingController.gameObject.SetActive(false);
			LiveController.gameObject.SetActive(true);
			LiveController.Init(activity);
		} else {
			RecordingController.gameObject.SetActive(true);
			LiveController.gameObject.SetActive(false);
			RecordingController.Init(activity);
		}
	}
}