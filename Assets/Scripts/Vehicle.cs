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
<<<<<<< Updated upstream
		if (collision.gameObject.CompareTag("Obstacle"))
=======
		_rigidBody.AddForce(Vector3.right * steerAmount, ForceMode.Impulse);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("Player"))
>>>>>>> Stashed changes
		{
			Destroy(gameObject);
		}
	}
}
