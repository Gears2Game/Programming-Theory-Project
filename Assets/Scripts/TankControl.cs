using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankControl : MonoBehaviour
{
	[SerializeField] private float _speed;

	private Rigidbody _playerRb;
	private GameManager _gameManager;
	private bool _isOnGround;
	private bool _hasCollided = false;
	private float _collisionTimer = 0f;
	private float _collisionTime = 0.5f;
	private float _zBoundary = 15;

	void Start()
	{
		_playerRb = GetComponent<Rigidbody>();
		_gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	void Update()
	{
		// ABSTRACTION
		MovePlayerOnGround();
		PreventMovementOnBoundary();
		UpdateCollisionTimer();
	}

	private void UpdateCollisionTimer()
	{
		_collisionTimer += Time.deltaTime;

		if (_collisionTimer > _collisionTime)
		{
			_hasCollided = false;
		}
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

	private void MovePlayerOnGround()
	{
		float setHorizontalInput = Input.GetAxis("Horizontal");
		float setVerticalInput = Input.GetAxis("Vertical");

		if (_isOnGround && !_gameManager.IsGameOver)
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
			Destroy(collision.gameObject);
			if (_hasCollided) return;

			_gameManager.ReducePowerUpAmount();
			_collisionTimer = 0f;
			_hasCollided = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
			Destroy(other.gameObject);
			_gameManager.IncreasePowerUpAmount();
		}
	}
}
