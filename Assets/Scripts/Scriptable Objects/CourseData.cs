using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Course", menuName = "Course", order = 0)]
public class CourseData : ScriptableObject {
	public string Name;
	[Multiline] public string Description;
	public string Instructors;
	[Space]
	public CourseActivity LiveActivity;
	public CourseActivity NewRecordingActivity;
	public List<CourseActivity> AllActivity;

}