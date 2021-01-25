using System;
using System.Collections.Generic;
using UnityEngine;

public class NavigableController : MonoBehaviour {
	private static NavigableController instance;
	public static NavigableController Instance => instance;

	public NavigablePage StartPage;
	public bool StartNavigation;
	public GameObject Navigation;
	public CoursePage CoursePage;
	public VideoPlayerPage VideoPlayerPage;
	public NavigationBarController NavigationBarController;

	private NavigablePage activePage;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Debug.LogError("There can only be one instance of NavigableController active");
			Destroy(this);
		}
	}

	private void Start() {
		OpenPage(StartPage);
		SetNavigation(StartNavigation);
	}

	public void SetNavigation(bool active) {
		Navigation.SetActive(active);
	}

	public void OpenPage(NavigablePage page) {
		if (activePage != null) activePage.Close();
		activePage = page;
		if (activePage != null) activePage.Open();
	}

	public void OpenCourse(CourseData courseToOpen) {
		NavigationBarController.UnlockButton();
		OpenPage(CoursePage);
		CoursePage.LoadCourse(courseToOpen);
	}

	public void OpenActivity(CourseActivity activity, bool isLive) {
		NavigationBarController.UnlockButton();
		OpenPage(VideoPlayerPage);
		VideoPlayerPage.LoadVideo(activity, isLive);
	}
}