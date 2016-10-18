using UnityEngine;
using System.Collections;

public class WayPointItem : MonoBehaviour {

	//public POI personOfInterest;

	void OnTriggerEnter (Collider other){
		if (other.tag == "POI" && other.GetComponent<POI>().isFollowingPlayer != true) {
			other.GetComponent<POI> ().MoveToNextTarget ();
		} else {
		}
	}
}
