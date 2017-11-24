using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;


public class ButtonScript : MonoBehaviour {

	public GameControlScript _gameControlScript;

	public void Start(){
		_gameControlScript = FindObjectOfType<GameControlScript>();
	}

	public void LoadMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void ResumeGame(){
		_gameControlScript.unpauseGame();
	}
}
