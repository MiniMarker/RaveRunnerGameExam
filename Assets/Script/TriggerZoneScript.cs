using UnityEngine;

public class TriggerZoneScript : MonoBehaviour
{
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}