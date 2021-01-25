using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RecordingController : MonoBehaviour {
	public TextMeshProUGUI TotalTimerText;
	public TextMeshProUGUI ProgressTimerText;
	public Image VideoImage;
	public Slider ProgressSlider;
	public GameObject PlayButton;
	public GameObject PauseButton;

	private float timer;
	private bool isPlaying = true;
	private TimerTime current;
	private TimerTime total;
	private CourseActivity activity;
	
	public void Init(CourseActivity activity) {
		this.activity = activity;
		current = new TimerTime(0, 0, 0);
		timer = 0.0f;
		total = new TimerTime(activity.Duration);
		ProgressSlider.value = (float) current.Seconds / total.Seconds;
		TotalTimerText.text = activity.Duration;
		ProgressTimerText.text = current.ToString();
		StartCoroutine(LoadImage("https://picsum.photos/1280/720"));
		Play();
	}

	private void Update() {
		if(!isPlaying || activity == null) return;
		timer += Time.deltaTime;
		if (timer >= 1.0f) {
			timer -= 1.0f;
			current.Increment();
			ProgressTimerText.text = current.ToString();
			ProgressSlider.value = (float) current.Seconds / total.Seconds;
			if(current.Seconds == total.Seconds) Pause();
		}
	}

	public void Play() {
		isPlaying = true;
		PlayButton.SetActive(false);
		PauseButton.SetActive(true);
		if (current.Seconds >= total.Seconds) {
			current = new TimerTime(0, 0, 0);
			ProgressTimerText.text = current.ToString();
			ProgressSlider.value = (float) current.Seconds / total.Seconds;
		}
	}

	public void Pause() {
		isPlaying = false;
		PlayButton.SetActive(true);
		PauseButton.SetActive(false);
	}

	public void SetProgress(float progress) {
		int progressSeconds = Mathf.FloorToInt(total.Seconds * progress);
		current = new TimerTime(0, 0, progressSeconds);
		ProgressTimerText.text = current.ToString();
		if(current.Seconds == total.Seconds) Pause();
	}
	
	private IEnumerator LoadImage(string url) {
		var downloadHandler = new DownloadHandlerTexture();
		UnityWebRequest webRequest = new UnityWebRequest(url, "GET", downloadHandler, null);
		webRequest.SendWebRequest();
		while (!downloadHandler.isDone) {
			yield return null;
		}

		var texture = downloadHandler.texture;
		VideoImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
		downloadHandler.Dispose();
		webRequest.Dispose();
	}

	private class TimerTime {
		public int Seconds;

		public TimerTime(string time) {
			if (!IsValid(time)) {
				Seconds = -1;
				return;
			}

			var timeSplit = time.Split(':');
			var hours = int.Parse(timeSplit[0]);
			var minutes = int.Parse(timeSplit[1]);
			Seconds = int.Parse(timeSplit[2]) + 60 * minutes + 3600 * hours;
		}

		public TimerTime(int hours, int minutes, int seconds) {
			Seconds = seconds + 60 * minutes + 3600 * hours;
		}

		public void Increment() {
			Seconds++;
		}

		public override string ToString() {
			var seconds = Seconds % 60;
			if(seconds < 0) seconds = 0;
			var minutes = (Seconds / 60) % 60;
			if(minutes < 0) minutes = 0;
			var hours = (Seconds / 60 / 60);
			if(hours < 0) hours = 0;
			return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
		}

		public static bool IsValid(string time) {
			var timeSplit = time.Split(':');

			if (timeSplit.Length == 3) {
				return int.TryParse(timeSplit[0], out _) &&
				       int.TryParse(timeSplit[1], out _) &&
				       int.TryParse(timeSplit[2], out _);
			}

			return false;
		}
	}

}