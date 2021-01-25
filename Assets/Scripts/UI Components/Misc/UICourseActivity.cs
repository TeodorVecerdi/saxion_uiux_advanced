using TMPro;

public class UICourseActivity : UIComponent {
	public CourseActivity CourseActivity;
	public bool Live;
	[AutoRef("LOWER/SCROLL_DESC/VIEWPORT/DESCRIPTION")]
	private TextMeshProUGUI classNameRef;
	
	public void OpenActivity() {
		NavigableController.Instance.OpenActivity(CourseActivity, Live);
	}
	
	public override void AutoUI() {
		if(CourseActivity == null) return;
		
		classNameRef.text = $"{CourseActivity.ClassName} {(Live ? "(In progress)": $"(Duration: {CourseActivity.Duration})")}";
	}
}