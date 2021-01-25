using TMPro;
using UnityEngine;

public class UICourseEntryB : UIComponent {
	public CourseData Course;

	[AutoRef("CONTENTS/COURSE_SCROLL/Viewport/COURSE")]
	private TextMeshProUGUI courseNameRef;

	[AutoRef("CONTENTS/ACTIVITY/LIVE", getGameObject:true)]
	private GameObject activityLiveRef;
	[AutoRef("CONTENTS/ACTIVITY/REC", getGameObject:true)]
	private GameObject activityRecRef;

	public override void AutoUI() {
		if(Course == null) return;

		courseNameRef.text = Course.Name;

		if (Course.LiveActivity != null) {
			activityLiveRef.gameObject.SetActive(true);
		} else {
			activityLiveRef.gameObject.SetActive(false);
		}

		if (Course.NewRecordingActivity != null) {
			activityRecRef.gameObject.SetActive(true);
		} else {
			activityRecRef.gameObject.SetActive(false);
		}
	}

	public void OpenCourse() {
		NavigableController.Instance.OpenCourse(Course);
	}
}