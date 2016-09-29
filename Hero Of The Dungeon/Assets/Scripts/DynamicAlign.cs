using UnityEngine;
using System.Collections;

public class DynamicAlign : MonoBehaviour {
	public Vector3 target;
	public float speed;

	public int maxAngAcc = 120;
	public int maxRotSpd = 120;
	public float targetRadius = 0.1f;
	public float slowRadius   = 7.0f;
	public float timeToTarget = 0.1f;


	// Use this for initialization
	void Start () {
		target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = target - transform.position;

		/* Get current orientation on the y-axis */
		float a = transform.eulerAngles.y;
		float b = Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg;
		/* Calculate the angle to the target */
		float r = Mathf.DeltaAngle(a, b);
		/* The value of r can be negative, take its magnitude (abs) */
		float rotationSize = Mathf.Abs(r);
		if(rotationSize < targetRadius) {
			/* We are within an acceptable margin. */
			return;
		}

		/* Similar to arriving, let's create a targetRotation */
		float targetRotation = 0.0f;
		if(rotationSize > slowRadius) {
		/* We still have angles to cover. */
			targetRotation = maxRotSpd;
		} else {
			targetRotation = maxRotSpd * rotationSize / slowRadius;
		}
		/* Let's get the direction (cw or ccw) */
		targetRotation *= r/rotationSize; /* r/rotationSize is either 1 or -1 */

		/* Similar to arrival, let's try to get to the target rotation */
		/* We look at the difference once again. */
		float angular = (targetRotation - speed)/timeToTarget;

		/* Let's see if we exceed max acc. */
		float angAcc  = Mathf.Abs (angular);
		if(angAcc > maxAngAcc) {
			angular /= angAcc; // This makes angular 1 or -1
			angular *= maxAngAcc;
		}

		speed += angular;
		transform.rotation = Quaternion.Euler(0, a + speed*Time.deltaTime, 0);

	}
}
