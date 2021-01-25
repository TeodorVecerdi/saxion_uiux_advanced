using TMPro;
using UnityEngine;

public class UICourseEntry : UIComponent {
	public CourseData Course;

	[AutoRef("CONTENTS/INFO/COURSE/COURSE")]
	private TextMeshProUGUI courseNameRef;
	[AutoRef("CONTENTS/INFO/SCROLL_DESC/VIEWPORT/TEXT")]
	private TextMeshProUGUI courseDescRef;
	[AutoRef("CONTENTS/INFO/SCROLL_INSTR/VIEWPORT/TEXT")]
	private TextMeshProUGUI courseInstrRef;

	[AutoRef("CONTENTS/ACTIVITY/LIVE")]
	private UICourseActivity activityLiveRef;
	[AutoRef("CONTENTS/ACTIVITY/REC")]
	private UICourseActivity activityRecRef;
	[AutoRef("CONTENTS/ACTIVITY/NONE", getGameObject: true)]
	private GameObject activityNoneRef;

	public override void AutoUI() {
		if(Course ==  null) return;

		courseNameRef.text = Course.Name;
		courseDescRef.text = Course.Description;
		courseInstrRef.text = Course.Instructors;

		if (Course.LiveActivity != null) {
			activityLiveRef.gameObject.SetActive(true);
			activityLiveRef.Live = true;
			activityLiveRef.CourseActivity = Course.LiveActivity;
			activityLiveRef.AutoUI();
		} else {
			activityLiveRef.gameObject.SetActive(false);
		}

		if (Course.NewRecordingActivity != null) {
			activityRecRef.gameObject.SetActive(true);
			activityRecRef.Live = false;
			activityRecRef.CourseActivity = Course.NewRecordingActivity;
			activityRecRef.AutoUI();
		} else {
			activityRecRef.gameObject.SetActive(false);
		}

		activityNoneRef.SetActive(Course.LiveActivity == null && Course.NewRecordingActivity == null);
	}

	public void OpenCourse() {
		NavigableController.Instance.OpenCourse(Course);
	}
}