using UnityEngine;

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
			_jumping = true;
		}

		if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.DownArrow)) {
			_animator.SetTrigger("Roll");
		}

		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Roll")) {
			_rolling = true;
		} else {
			_rolling = false;

		}
		if (Input.GetKey (KeyCode.P)) {
			
			if (!_gameControlScript.getPaused()) {
				
				_gameControlScript.pauseGame ();
				Pause ();
			} else {
				_gameControlScript.unpauseGame ();
				Pause ();
			}
		}
	}

	public void Pause(){
		foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {

			if (obj.tag == "canvas") {
				
				if (canvas.gameObject.activeInHierarchy == false) {
					canvas.gameObject.SetActive (true);
				} else {
					canvas.gameObject.SetActive (false);
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
					timer += 0.1f;

				}

		}


			_gameControlScript.PowerupCollected ();

		} else if (other.gameObject.name == "Obstacle(Clone)" && !_jumping) {
			int timePenalty = (int)_gameControlScript.getTime();

			_gameControlScript.reduceTime(timePenalty);

		} else if (other.gameObject.name == "debuffCap(Clone)") { 
			t.smokebomb ();


		} else if (other.gameObject.name == "ObstacleCylinder(Clone)" && !_rolling) {
			_gameControlScript.SlowWorldDown ();
		
			
		}
	
		Destroy(other.gameObject);
	}




}