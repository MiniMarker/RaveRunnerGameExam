using UnityEngine;
using UnityEngine.UI;
public class GameControlScript : MonoBehaviour {
	
	public float ScrollSpeed = 25f; // Number of units we scroll each second.
	public float TimeExtension = 1.5f; // Time-extension (in seconds) for a pickup.
	public MoveGroundScript MoveGroundScript;
	private bool paused=false;
	private float _timeRemaining = 10;
	private float _totalTimeElapsed;
	private bool _isGameOver;
	public float difficulty;
	private int count = 0;
	public Text scoreText;
	public Text timeText;

	void Start(){

		SetScoreText ();
		SetTimeText ();
	}
	public void PowerupCollected() {
		count += 1;

		SetScoreText ();
		_timeRemaining += TimeExtension;
		//counter.ToString ();
		//score =  counter.ToString();
	}
	public float getTime(){
		return _timeRemaining;
	}
	public void reduceTime(float numb){
		_timeRemaining -= _totalTimeElapsed + numb;
	}

	public void SlowWorldDown() {
		CancelInvoke("RestoreWorldSpeed"); // Cancel any cued commands to restore world speed.
		Invoke("RestoreWorldSpeed", 1); // Speed the world up again after this duration.
		Time.timeScale = 0.5f;
	}
	void RestoreWorldSpeed() {
		Time.timeScale = 1f;
	}
	public void setWorldSpeed(float num){
		Time.timeScale = num;
	}
	public bool getPaused(){return paused;}
	public void pauseGame(){
		Time.timeScale = 0f;
		paused = true;
	}
	public void unpauseGame(){
		
		Time.timeScale = 1f;
		paused = false;
	}

	void SetScoreText(){
		scoreText.text = "Score: " + count.ToString ();
	}

	void SetTimeText(){
		timeText.text = "Time Left: " + getTime().ToString();
	}

	void Update() {
		

		if (_isGameOver) {
			foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {

				if (obj.tag == "gameover") {
					obj.SetActive (true);
				}
				if (obj.tag == "Gameoverscreen") {
					obj.SetActive (true);
				}
			}
			Time.timeScale = 0;
			return;
		}
		if(getPaused()!=true){
			_totalTimeElapsed += Time.deltaTime;
			_timeRemaining -= Time.unscaledDeltaTime; // This one is not affected by timeScale.
		}
		if (_timeRemaining <= 0) {
			_isGameOver = true;
		}

	}
}