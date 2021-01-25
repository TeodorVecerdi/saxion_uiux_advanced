using DG.Tweening;
using UnityEngine;

public class HomePage : NavigablePage {
	public UITile ActivityPrefab;
	public Transform LiveTransform;
	public Transform RecordingsTransform;
	public GameObject NoLiveObject;
	public GameObject NoRecordingsObject;
	
	public override void Open() {
		base.Open();
		foreach (var t in RecordingsTransform.GetComponentsInChildren<Transform>()) {
			if(t == RecordingsTransform) continue;
			Destroy(t.gameObject);
		}
		
		foreach (var t in LiveTransform.GetComponentsInChildren<Transform>()) {
			if(t == LiveTransform) continue;
			Destroy(t.gameObject);
		}
		
		foreach (var course in CourseCollection.Instance.Courses) {
			if (course.LiveActivity != null) {
				var liveObject = Instantiate(ActivityPrefab, LiveTransform);
				liveObject.CourseActivity = course.LiveActivity;
				liveObject.IsLive = true;
				liveObject.Title = course.Name;
				liveObject.ForceReference();
				liveObject.AutoUI();
			}

			if (course.NewRecordingActivity != null) {
				var recordingObject = Instantiate(ActivityPrefab, RecordingsTransform);
				recordingObject.CourseActivity = course.NewRecordingActivity;
				recordingObject.IsLive = false;
				recordingObject.Title = course.Name;
				recordingObject.ForceReference();
				recordingObject.AutoUI();
			}
		}
		NoLiveObject.SetActive(LiveTransform.childCount == 0);
		NoRecordingsObject.SetActive(RecordingsTransform.childCount == 0);
		
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