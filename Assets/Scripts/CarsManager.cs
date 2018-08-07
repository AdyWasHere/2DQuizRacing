using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsManager : MonoBehaviour {

	public float travelDistance;
	public float backOrForward;
	//creates a variable outside the Update function to hold the distance traveled
	float m_distanceTraveled = 0f;

	void Update() {

		//checks to see if the distance traveled is less than 100 * f
		if (m_distanceTraveled < travelDistance) {
			//if it is, creates a variable to hold the object's current position
			Vector3 oldPosition = transform.position;
			//then moves the object forward 1 unit per frame
			transform.Translate(0,backOrForward,0 * Time.deltaTime);
			//and increases the distance traveled by the difference between the old and new position
			m_distanceTraveled += Vector3.Distance(oldPosition, transform.position);
		}
	}

	public void MoveForward()
	{

		backOrForward = 0.01f;
		travelDistance++;

	}

	public void MoveBack()
	{

		backOrForward = -0.01f;
		travelDistance--;

	}
}
