using TMPro;

[ManualRef]
public class Timer : UIComponent {
	public string Time = "00:00:00";
	public bool IsFixed;
	public string TextPath = "BOTTOM/TIMER";
	public string SecondaryTextPath = "BOTTOM/SECONDARY";

	private TextMeshProUGUI timerText;
	private TextMeshProUGUI secondaryText;
	private TimerTime time;
	private float timer;

	private void Update() {
		if(IsFixed || time == null) return;

		if (timer >= 1f) {
			timer -= 1f;
			time.Increment();
			AutoUI();
		}

		timer += UnityEngine.Time.deltaTime;
	}

	public override void AutoUI() {
		if (time == null) {
			var isValid = TimerTime.IsValid(Time);
			if (isValid) time = new TimerTime(Time);
		}

		if (time != null) {
			timerText.text = time.ToString();
		}

		if (IsFixed) secondaryText.text = "DURATION";
		else secondaryText.text = "IN PROGRESS";
	}

	protected override void GetReferences() {
		if (timerText == null) timerText = transform.GetComponentRecursive<TextMeshProUGUI>(TextPath);
		if (secondaryText == null) secondaryText = transform.GetComponentRecursive<TextMeshProUGUI>(SecondaryTextPath);
		if (time == null) {
			var isValid = TimerTime.IsValid(Time);
			if (isValid) time = new TimerTime(Time);
		}
	}

	protected override void ForceGetReferences() {
		timerText = transform.GetComponentRecursive<TextMeshProUGUI>(TextPath);
		secondaryText = transform.GetComponentRecursive<TextMeshProUGUI>(SecondaryTextPath);
		
		var isValid = TimerTime.IsValid(Time);
		if (isValid) time = new TimerTime(Time);
	}

	private class TimerTime {
		public int Hours;
		public int Minutes;
		public int Seconds;

		public TimerTime(string time) {
			if (!IsValid(time)) {
				Hours = Minutes = Seconds = -1;
				return;
			}

			var timeSplit = time.Split(':');
			Hours = int.Parse(timeSplit[0]);
			Minutes = int.Parse(timeSplit[1]);
			Seconds = int.Parse(timeSplit[2]);
		}

		public TimerTime(int hours, int minutes, int seconds) {
			Hours = hours;
			Minutes = minutes;
			Seconds = seconds;
		}

		public void Increment() {
			Seconds++;
			if (Seconds >= 60) {
				Seconds -= 60;
				Minutes++;
			}

			if (Minutes >= 60) {
				Minutes -= 60;
				Hours++;
			}
		}

		public override string ToString() {
			return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
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