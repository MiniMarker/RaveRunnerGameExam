using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript : MonoBehaviour {

	public DifficultyScript _DiffControlScript;
	public GameControlScript _gameControlScript;
	public void Start(){
		_DiffControlScript = FindObjectOfType<DifficultyScript>();
		_gameControlScript = FindObjectOfType<GameControlScript> ();
	}

	public void LoadMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene ("MainMenu");

	}
	public void retry(){
        Time.timeScale = 1f;
        SceneManager.LoadScene ("Gauntlet Runner");
		GameControlScript._isGameOver = false;


	}

	public void ResumeGame(){
		PlayerScript.PauseMenu ();
		_gameControlScript.unpauseGame();

	}
	public void choiceEasy(){
		_DiffControlScript.setDiff( 0.7f);
	}
	public void choiceMed(){
		_DiffControlScript.setDiff( 1f);
	}
	public void choiceHard(){
		_DiffControlScript.setDiff( 2f);
	
	}
}
