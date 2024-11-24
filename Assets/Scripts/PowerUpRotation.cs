using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Imported Script to simply rotate the powerups
/// </summary>
public class PowerUpRotation : MonoBehaviour
{

	#region Settings
	public float rotationSpeed = 99.0f;
	public bool reverse = false;
	#endregion

	void Update ()
	{
		if(this.reverse)
			transform.Rotate(new Vector3(0f,0f,1f) * Time.deltaTime 
				* this.rotationSpeed);
		else
			transform.Rotate(new Vector3(0f,0f,1f) * Time.deltaTime 
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
