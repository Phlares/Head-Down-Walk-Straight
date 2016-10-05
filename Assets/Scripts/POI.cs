using UnityEngine;
using System.Collections;

public class POI : MonoBehaviour {

	//Credits:
	//Thank you http://answers.unity3d.com/questions/949222/is-raycast-efficient-in-update.html for helping me understand rays

	//Declaring a hit container
	public RaycastHit myHit;

	//Declaring a Ray
	Ray myRay;

	//Set the game object/transform you want to shoot the ray from
	//public Transform rayCastStart;

	//Setting the Raycast Direction


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		myRay = new Ray(transform.position, transform.forward);
		//A start position for the ray
		Vector3 startMarker = transform.position;
		CastRay();


		//Do the RayCast each frame
		//CastRay ();

		//Drawing the ray with color and making it long (*1000)
		Debug.DrawRay(startMarker, myRay.direction * 1000, Color.magenta);

	}

	public void CastRay(){
		
		//Actually casting the ray ==> Outputs collider to myHit ("out" keyword)
		Physics.Raycast (myRay, out myHit, 15f );

		//prints collider hit, filtering null errors
		if (myHit.collider != null) {
			Debug.Log (myHit.collider.gameObject);
		} else {
			
		}
	}
}
