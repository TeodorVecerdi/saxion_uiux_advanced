using DG.Tweening;

public class CoursesPage : NavigablePage {
	public bool AutoLoadCourses;
	public UICourseEntry CoursePrefab;
	private void Start() {
		if(!AutoLoadCourses) return;

		var courseContainer = transform.FindChildRecursive("Contents/Viewport/Content");
		var childCount = courseContainer.childCount;
		while (--childCount > 0) {
			var child = courseContainer.GetChild(0);
			Destroy(child.gameObject);
		}
		foreach (var courseData in CourseCollection.Instance.Courses) {
			var course = Instantiate(CoursePrefab, courseContainer);
			course.Course = courseData;
			course.ForceReference();
			course.AutoUI();
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