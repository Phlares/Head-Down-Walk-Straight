using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class POI : MonoBehaviour {

	//Credits:
	//Thank you http://answers.unity3d.com/questions/949222/is-raycast-efficient-in-update.html for helping me understand rays

	public bool isFollowingPlayer = false;
	//Declaring a hit container
	public RaycastHit myHit;

	//Declaring a Ray
	Ray myRay;

	//timer stuff

	public float followTimer;
	public float myTimer;
	//waypointmanager
	public WayPointManager wayPointManagerino;
	public Transform[] waypointLocationsPOI;
	public bool hasTarget;

	//Set the game object/transform you want to shoot the ray from
	//public Transform rayCastStart;

	//Setting the Raycast Direction


	// Use this for initialization
	void Start () {
		wayPointManagerino = GameObject.Find ("WayPointManager").GetComponent<WayPointManager> ();
		waypointLocationsPOI = wayPointManagerino.objectLocationsPOI;
		MoveToNextTarget ();
	}
	void Awake ()
	{
		myTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		myRay = new Ray(transform.position, transform.forward * 15f);
		//A start position for the ray
		Vector3 startMarker = transform.position;
		CastRay();
		//Do the RayCast each frame
		//CastRay ();
		//Drawing the ray with color and making it long (*1000)
		Debug.DrawRay(startMarker, myRay.direction * 15f, Color.magenta);
		if (isFollowingPlayer == true) {
			Debug.Log ("Following Player");
			gameObject.GetComponent<AICharacterControl> ().target = GameObject.Find ("Player").transform;
		}

	}

	public void CastRay(){
		
		//Actually casting the ray ==> Outputs collider to myHit ("out" keyword)
		Physics.Raycast (myRay, out myHit, 15f );

		//prints collider hit, filtering null errors
		if (myHit.collider != null) {
		//	Debug.Log (myHit.collider.gameObject);
			if (myHit.collider.gameObject.tag == "Player") {
				Debug.Log ("Trying To follow player");
				isFollowingPlayer = true;
				TimerForFollow ();
			} 
			if (myHit.collider.gameObject.tag != "Player" && isFollowingPlayer == false) {
				Debug.Log ("StopFollowingPlayer");

				if (gameObject.GetComponent<AICharacterControl> ().target == GameObject.Find ("Player").transform) {
					MoveToNextTarget ();
				}

			} else {
			}
		}


		else {
			
		}
	}

	void TimerForFollow()
	{

		if (isFollowingPlayer == true)
			{
				if (myTimer >= Time.time) {
					//Debug.Log (myTimer + "  and the time is" + Time.time);
				} else {
				myTimer = Time.time + followTimer;
				isFollowingPlayer = false;
				}
			}
	
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			Debug.Log ("YOU ARE BEING STOPPED SCRIPT TO BE IMPLEMENTED");
		}
	}
	public void MoveToNextTarget(){
		gameObject.GetComponent<AICharacterControl>().target = waypointLocationsPOI[Random.Range (0, waypointLocationsPOI.Length)];
	}
}
