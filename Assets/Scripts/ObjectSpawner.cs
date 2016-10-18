using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	public Transform[] spawnerLocations;
	public GameObject elementToSpawn;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnNextObject(){
		GameObject elementSpawning =  elementToSpawn;

		Instantiate (elementSpawning);

		elementSpawning.transform.position =spawnerLocations[Random.Range (0, spawnerLocations.Length)].transform.position;
	}
}
