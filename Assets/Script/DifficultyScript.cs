using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour {
	private float timeValue=1f;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setDiff(float timevalue){
		timeValue = timevalue;
		
	}
	public float getDiff(){
		return timeValue;
	}
}
