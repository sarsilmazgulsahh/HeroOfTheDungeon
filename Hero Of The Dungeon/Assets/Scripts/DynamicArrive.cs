using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DynamicArrive : MonoBehaviour {

	public Vector3 target; 

	public Vector3 velocity;
	public float speedVal = 5.0f;

	public float slowRadius = 5.0f;
	public float targetRadius = 0.1f;
	public float maxAcceleration = 10f;
	
	public float timeToTarget = 0.01f;

//	public float maxAcceleration = 1;

	public List<Edge> edges = new List<Edge>();



	[HideInInspector]
	public int currentNode = 0;

	public bool vall;
		
	// Use this for initialization
	void Start () {

		velocity = new Vector3(0, 0, 0);

	}



	// Update is called once per frame
	void Update () {
		if (vall == true) {

		
			target = edges [currentNode].to.getValue ();

			transform.LookAt(target);

			Vector3 direction = target - transform.position;
		

			float   distance  = direction.magnitude;
			if( distance < targetRadius ) {
				/* We are within an acceptable margin of stopping. */
				return;
			}


			if (direction.magnitude < 1f) {

				ChangeNode ();
			}
		


			float targetSpeed = 0;
			if(distance > slowRadius) {

				/* We are still out of slowRadius. Pedal to the metal. */


				targetSpeed = speedVal;

			} else {
				/* The distance/slowRadius will always be less than 1. */
				targetSpeed = speedVal * (distance / slowRadius);
			}


			/* Let's create the acceleration. */
			Vector3 targetAcceleration = ((direction.normalized * targetSpeed) - velocity)/timeToTarget;
			if(targetAcceleration.magnitude>maxAcceleration) {
				targetAcceleration = targetAcceleration.normalized * maxAcceleration;
			}
			
			/* Now that we have an acceleration, let's update velocity.
		 * We also check if we exceed maxSpeed. 
		 */
			velocity += targetAcceleration * Time.deltaTime;
			if(velocity.magnitude > speedVal) {
				velocity = velocity.normalized * speedVal;
			}

			transform.Translate (velocity * Time.deltaTime, Space.World);
		}

	}

	void ChangeNode () {
		int edgeCount = edges.Count;

		if (currentNode == edgeCount-1)
			return;

		if (currentNode == null)
			currentNode = 0;

		currentNode ++;


	}


}
