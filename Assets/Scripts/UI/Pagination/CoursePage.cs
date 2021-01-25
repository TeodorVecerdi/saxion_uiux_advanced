using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoursePage : NavigablePage {
	public CourseData Course;
	public UICourseTile ActivityPrefab;

	public TextMeshProUGUI CourseNameText;
	public TextMeshProUGUI CourseDescriptionText;
	public TextMeshProUGUI CourseInstructorsText;
	public Transform RecordingsContainer;
	public GameObject NotLiveObject;
	public UICourseTile LiveObject;
	
	public void LoadCourse(CourseData course) {
		Course = course;
		InitUI();
	}

	private void InitUI() {
		if(Course == null) return;

		CourseNameText.text = Course.Name;
		CourseDescriptionText.text = Course.Description;
		CourseInstructorsText.text = Course.Instructors;
		
		foreach (var t in RecordingsContainer.GetComponentsInChildren<Transform>()) {
			if(t == RecordingsContainer) continue;
			Destroy(t.gameObject);
		}

		foreach (var activity in Course.AllActivity) {
			var activityObject = Instantiate(ActivityPrefab, RecordingsContainer);
			activityObject.CourseActivity = activity;
			activityObject.ForceReference();
			activityObject.AutoUI();
		}

		if (Course.LiveActivity != null) {
			LiveObject.CourseActivity = Course.LiveActivity;
			LiveObject.ForceReference();
			LiveObject.AutoUI();
			LiveObject.gameObject.SetActive(true);
			NotLiveObject.SetActive(false);
		} else {
			LiveObject.gameObject.SetActive(false);
			NotLiveObject.SetActive(true);
		}
	}
	
	public override void Open() {
		base.Open();
		foreach (var scroller in GetComponentsInChildren<TextScroller>()) {
			scroller.InitScrolling();
		}
	}
	
	public override void Close() {
		foreach (var scroller in GetComponentsInChildren<TextScroller>()) {
			scroller.Tweener?.Kill();
			scroller.StopAllCoroutines();
		}
		base.Close();
	}
}