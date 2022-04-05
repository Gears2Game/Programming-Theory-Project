using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankControl : MonoBehaviour
{
	// ENCAPSULATION
	public int PowerUpAmount { get; private set; }

	[SerializeField] private Rigidbody _projejctile;
	[SerializeField] private float _projectileForce;
	[SerializeField] private float _speed;
	[SerializeField] private TMP_Text _powerAmountText;

	private Rigidbody _playerRb;
	private int _setPowerUpAmount = 3;
	private bool _isOnGround;
	private bool _hasCollided = false;
	private float _collisionTimer = 0f;
	private float _collisionTime = 0.5f;
	private float _zBoundary = 15;

	void Start()
	{
		_playerRb = GetComponent<Rigidbody>();
		PowerUpAmount = _setPowerUpAmount;
		DisplayPowerAmount();
	}

	

	void Update()
	{
		// ABSTRACTION
		MovePlayerOnGround();
		Attack();
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
			Destroy(collision.gameObject);
			if (_hasCollided) return;

			PowerUpAmount--;
			_collisionTimer = 0f;
			_hasCollided = true;
			DisplayPowerAmount();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
			Destroy(other.gameObject);
			PowerUpAmount++;
			DisplayPowerAmount();
		}
	}

	private void DisplayPowerAmount()
	{
		_powerAmountText.text = PowerUpAmount.ToString();
	}
}
