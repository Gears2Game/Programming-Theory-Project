using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
	private Rigidbody _rigidBody;

	void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	public void MoveForward(float speed)
	{
		_rigidBody.AddForce(Vector3.forward * -(speed + Random.Range(1f,10f)), ForceMode.Force);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}
	}
}
