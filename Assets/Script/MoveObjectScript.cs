using UnityEngine;

public class MoveObjectScript : MonoBehaviour
{
	private GameControlScript _gameControlScript;

	void Start() {
		_gameControlScript = FindObjectOfType<GameControlScript>();
	}

	void Update() {
		float offset = _gameControlScript.ScrollSpeed * Time.deltaTime;
		transform.Translate(0, 0, -offset, Space.World);
	}
}