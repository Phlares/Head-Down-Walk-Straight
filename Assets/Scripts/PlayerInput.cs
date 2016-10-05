using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public float currentMovementSpeed;
	public bool canMove;
	public float xAxis = 0;
	public float zAxis = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Script borrowed from previous game jam "BadTrip" Matt Ferriera helped write it.
	void FixedUpdate ()
	{
		xAxis = Input.GetAxisRaw("Horizontal"); //Getting values for X Axis
		zAxis = Input.GetAxisRaw("Vertical");   //Getting values for Z Axis

		if (xAxis != 0 || zAxis != 0)   //If there is movement, call method from PlayerController
		{
			Movement(xAxis, zAxis);
		}


	}
		public void Movement(float xAxis, float zAxis)
			{
				if (xAxis != 0 && canMove == true)
				{
					if (xAxis > 0)  //Move right, else move left
					{
						gameObject.transform.Translate(new Vector3(currentMovementSpeed, 0, 0) * Time.deltaTime);
					}
					else
					{
						gameObject.transform.Translate(new Vector3(-currentMovementSpeed, 0, 0) * Time.deltaTime);
					}
				}

				if (zAxis != 0 && canMove == true)
				{
					if (zAxis > 0) // Move forward else move backwards
					{
						gameObject.transform.Translate(new Vector3(0, 0, currentMovementSpeed) * Time.deltaTime);
					}
					else
					{
						gameObject.transform.Translate(new Vector3(0, 0, -currentMovementSpeed) * Time.deltaTime);
					}
				}
			}
}
