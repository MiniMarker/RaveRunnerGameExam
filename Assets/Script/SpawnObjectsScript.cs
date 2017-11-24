using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObjectsScript : MonoBehaviour
{
	public GameObject ObstaclePrefab;
	public GameObject PowerupPrefab;
	public GameObject debuffcapPrefab;
	public GameObject ParentofPsystem;
	public GameObject dodgeCyl;
	public GameObject duststorm;
	public GameObject workAround;
	public float SpawnCycle = 0.5f;
	public float spawndebuffcycle=1.5f;
	public float timeSinceLastdeBuff;
	public float timer=0f;

	public int konstantSlide=12;
	public float timer2=0;
	private float _timeElapsed;
	private bool _spawnPowerup = true;
	private bool _spawnJumpObs=false;


	void Update() {
		
 		_timeElapsed += Time.deltaTime;
		timeSinceLastdeBuff += Time.deltaTime;
		GameObject objectSpawned;
		Vector3 pos;
		int powerupCounter = 0;

		if (_timeElapsed > SpawnCycle) {
			
			if (_spawnPowerup) {
				objectSpawned = Instantiate (PowerupPrefab);
				powerupCounter++;
			} else{
				
				objectSpawned = Instantiate (ObstaclePrefab);
			}

			pos = objectSpawned.transform.position;

		
			objectSpawned.transform.position = new Vector3 (Random.Range (-4, 4), pos.y, pos.z);
		
			_timeElapsed -= SpawnCycle;
			_spawnPowerup = !_spawnPowerup;
			_spawnJumpObs = !_spawnJumpObs;
		}

		if (timeSinceLastdeBuff > spawndebuffcycle) {
			
			objectSpawned = Instantiate (debuffcapPrefab);
			pos = objectSpawned.transform.position;

			objectSpawned.transform.position = new Vector3 (Random.Range (-4, 4), pos.y, pos.z);
			timeSinceLastdeBuff -= 2*spawndebuffcycle;


		}  else {
			objectSpawned = null;
		}



		if (timer > konstantSlide * spawndebuffcycle) {
			konstantSlide = (int)Random.Range (9, 20);
			objectSpawned = Instantiate (dodgeCyl);
			timer = 0;
		}
		timer += 9f*Time.deltaTime;
		timer2 += 9f * Time.deltaTime;

	}

	public void smokebomb(){
		if (duststorm != null)
			return;
		 duststorm = Instantiate (ParentofPsystem);
		Destroy (duststorm, 6);
	}
}