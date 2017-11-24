using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	public float StrafeSpeed = 4f;

	public GameControlScript _gameControlScript;
	private Animator _animator;
	private bool _jumping;
	private bool _rolling;
	public AudioClip clip;
	private float timer=0f;
	private SpawnObjectsScript t;
	public Transform canvas;



	void Start() {
		_gameControlScript = FindObjectOfType<GameControlScript>();
		_animator = GetComponent<Animator>();
		t = FindObjectOfType<SpawnObjectsScript>();
	}

	void Update() {
		float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * StrafeSpeed;
		transform.Translate(xMove, 0f, 0f);
		if (transform.position.x > 4) {
			transform.Translate(4f - transform.position.x, 0, 0);
		} else if (transform.position.x < -4) {
			transform.Translate(-4f - transform.position.x, 0, 0);
		}

		if (Input.GetButtonDown("Jump")|| Input.GetKeyDown(KeyCode.UpArrow)) {
			_animator.SetTrigger("Jump");
		}

		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run")) {
			_jumping = false;
		} else {
			if (_animator.GetCurrentAnimatorStateInfo (0).IsName ("Roll")) {
				_jumping = false;
			} else {
				_jumping = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.DownArrow)) {
			_animator.SetTrigger("Roll");
		}

		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Roll")) {
			_rolling = true;
		} else {
			_rolling = false;

		}
		lololhackis ();
	}
	public void lololhackis(){
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
			PauseMenu ();
			if (!_gameControlScript.getPaused()) {

				_gameControlScript.pauseGame();
			} else {

				_gameControlScript.unpauseGame();
			}
		}
	}

	public static void PauseMenu(){
		
		
		foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {
			
			if (obj.tag == "canvas") {
				if (!obj.activeSelf) {
					
					obj.gameObject.SetActive (true);
				} else if(obj.activeSelf){
					obj.gameObject.SetActive (false);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.name == "PowerUp(Clone)") {
			
			foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
				
				if (obj.tag == "soundPop") {
					
					if (timer >= 0.7f * Time.deltaTime) {
						obj.SetActive (false);
					}
					obj.SetActive (true);

				}
		}


			_gameControlScript.PowerupCollected ();

		} else if (other.gameObject.name == "Obstacle(Clone)" && !_jumping ) {
			foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {

				if (obj.tag == "gameover") {
					obj.SetActive (true);
					int timePenalty = (int)_gameControlScript.getTime ();

					_gameControlScript.reduceTime (timePenalty);
				}
			}

		} else if (other.gameObject.name == "debuffCap(Clone)") { 
			foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {

				if (obj.tag == "gulp") {
					if (timer >= 0.7f * Time.deltaTime) {
						obj.SetActive (false);
					}
					obj.SetActive (true);
					t.smokebomb ();
				}
			}


		} else if (other.gameObject.name == "ObstacleCylinder(Clone)" && !_rolling) {
			foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {

				if (obj.tag == "obsSound") {
					if (timer >= 0.7f * Time.deltaTime) {
						obj.SetActive (false);
					}
					obj.SetActive (true);
					_gameControlScript.SlowWorldDown ();
					}
				}
		}
		timer += 0.1f;
		Destroy(other.gameObject);
	}
}