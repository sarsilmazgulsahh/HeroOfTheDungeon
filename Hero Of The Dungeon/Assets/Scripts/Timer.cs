using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text timerText;

	float timeLeft = 5 * 60;

	string FormatTime() {

		string timeText = "";
		timeText += ((int)timeLeft / 60).ToString();
		timeText += ":" + ((int)timeLeft % 60).ToString();

		return timeText;
	}

	void Update () {
	
		timeLeft -= Time.smoothDeltaTime;
		timerText.text = FormatTime();
	}
}
