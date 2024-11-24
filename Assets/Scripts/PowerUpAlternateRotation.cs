using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Copy of the imported PowerUpRotation Script, rotating around a different axis
/// </summary>
public class PowerUpAlternateRotation : MonoBehaviour
{

	#region Settings
	public float rotationSpeed = 99.0f;
	public bool reverse = false;
	#endregion

	void Update ()
	{
		if(this.reverse)
			transform.Rotate(new Vector3(0f,1f,0f) * Time.deltaTime 
				* this.rotationSpeed);
		else
			transform.Rotate(new Vector3(0f,1f,0f) * Time.deltaTime 
				* this.rotationSpeed);
	}

	public void SetRotationSpeed(float speed)
	{
		this.rotationSpeed = speed;
	}

	public void SetReverse(bool reverse)
	{
		this.reverse = reverse;
	}
}
