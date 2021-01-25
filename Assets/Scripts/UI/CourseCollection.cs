using System;
using System.Collections.Generic;
using UnityEngine;

public class CourseCollection : MonoBehaviour {
	public List<CourseData> Courses;
	
	private static CourseCollection instance;
	public static CourseCollection Instance => instance;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Debug.LogError("There can only be one instance of NavigableController active");
			Destroy(this);
		}
	}
}