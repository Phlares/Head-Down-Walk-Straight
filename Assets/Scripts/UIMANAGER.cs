using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMANAGER : MonoBehaviour {

	public Text timeText;
	public GameManager gameManagerino;

	// Use this for initialization
	void Start () {
		gameManagerino = GameObject.Find ("GameManagerObject").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		gameManagerino.DisplayTime(timeText);
	}
		
}
