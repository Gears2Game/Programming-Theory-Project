using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
	[SerializeField] private Rigidbody _projejctile;
	[SerializeField] private float _projectileForce;
	[SerializeField] private float _speed;

	private Rigidbody _playerRb;
	private bool _isOnGround;
	private float _zBoundary = 15;

	void Start()
	{
		_playerRb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		MovePlayerOnGround();
		Attack();
		PreventMovementOnBoundary();
	}

	private void PreventMovementOnBoundary()
	{
		if (transform.position.z > _zBoundary)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, _zBoundary);
		}

		if (transform.position.z < -_zBoundary)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, -_zBoundary);
		}
	}

	private void Attack()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_projejctile.AddForce(Vector3.forward * _projectileForce, ForceMode.Impulse);
		}
	}

	private void MovePlayerOnGround()
	{
		float setHorizontalInput = Input.GetAxis("Horizontal");
		float setVerticalInput = Input.GetAxis("Vertical");

		if (_isOnGround)
		{
			_playerRb.AddForce(Vector3.forward * _speed * setVerticalInput);
			_playerRb.AddForce(Vector3.right * _speed * setHorizontalInput);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			_isOnGround = true;
		}

		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Collided with the enemy");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
			Destroy(other.gameObject);
		}
	}
}
