using UnityEngine;
using System.Collections;

public class ObjectCollect : MonoBehaviour {
	public bool spawnNow;
	public float myTimer;
	public float spawnTimer;
	public ObjectSpawner objectSpawnerGuy;
	public GameManager gameManagerGuy;

	// Use this for initialization
	void Start () {
		objectSpawnerGuy = GameObject.Find ("StuffToCollect").GetComponent <ObjectSpawner>();
		gameManagerGuy = GameObject.Find ("GameManagerObject").GetComponent <GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();
		if (spawnNow) {
			//start collecting object
		}
	}

	void CollectObject(){
		Debug.Log("Collecting an object");
		gameManagerGuy.ChangeElementCount ("Collect");
		objectSpawnerGuy.SpawnNextObject ();
		Destroy (gameObject);
	}

	void Timer()
	{

		if (spawnNow == false)
		{
			if (myTimer >= Time.time) {
				//Debug.Log (myTimer + "  and the time is" + Time.time);
			} else {
				myTimer = Time.time + spawnTimer;
				spawnNow = true;
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") 
		{
			//spawnNow = true;
			CollectObject ();
		}

	}
}
