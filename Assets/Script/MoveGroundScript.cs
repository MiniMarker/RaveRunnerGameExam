using UnityEngine;

public class MoveGroundScript : MonoBehaviour{
	
	private float _normalizerScaleZ;
	private Material _groundMaterial;
	private GameControlScript _gameControlScript;

	void Start() {
		
		_normalizerScaleZ = 1f / transform.localScale.z;
		_groundMaterial = GetComponent<Renderer>().material;
		_gameControlScript = FindObjectOfType<GameControlScript>();
	}

	void Update() {
		
		// The % 1 ("modulus 1") keeps offset between 0 and 1. 
		float offset = (_gameControlScript.ScrollSpeed * (Time.time * _normalizerScaleZ)) % 1;
		_groundMaterial.mainTextureOffset = new Vector2(0, -offset);
	}
}
