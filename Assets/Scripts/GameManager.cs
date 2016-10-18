using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float timeToCollect;
	public int elementsLeftToCollect = 7;
	//public string[] namesOfPeople;
	public Transform storeEntrance;
	public bool spawnPOINow = false;
	public GameObject prefabPOI;
	public GameObject playerOne;
	public ObjectSpawner objectSpawnerGuy;


	// Use this for initialization
	void Start () {
		objectSpawnerGuy = GameObject.Find ("StuffToCollect").GetComponent <ObjectSpawner>();
		objectSpawnerGuy.SpawnNextObject ();
		Debug.Log ("GameStart");
	}
	
	// Update is called once per frame
	void Update () {
		if (elementsLeftToCollect <= 0) {
			GameWin ();
		}
		if ((elementsLeftToCollect == 5) && spawnPOINow) {
			spawnPOINow = true;
			SpawnPOI(prefabPOI);
			spawnPOINow = false;
		}
		if ((elementsLeftToCollect == 3) && spawnPOINow) {
			spawnPOINow = true;
			SpawnPOI(prefabPOI);
			spawnPOINow = false;
		}
		if ((elementsLeftToCollect == 1) && spawnPOINow) {
			spawnPOINow = true;
			SpawnPOI(prefabPOI);
			spawnPOINow = false;
		}
	
	}

	public void SpawnPOI(GameObject POIToSpawn)
	{
		if (spawnPOINow != false) {
			Instantiate (POIToSpawn);
			POIToSpawn.transform.position = storeEntrance.position;
			// Set NavMesh agent AI controller waypoints/targets
		}
		//SpawnPOI at Store Entrance
	}
	public void GameWin()
	{
		//You win!
		Debug.Log("You Win");
		Time.timeScale = 0;
		//Print time
		//Offer Restart
	}
	public void ChangeElementCount(string command)
	{
		switch (command){
		case ("Collect"):
			elementsLeftToCollect -= 1;
			break;
		case ("Add"):
			elementsLeftToCollect += 1;
			break;
		}
		Debug.Log ("There are " + elementsLeftToCollect + " objects left to collect");
	}
	public void DisplayTime(Text textTime)
	{
		textTime.text = "Time " + Mathf.Round(Time.time);
	}
}
