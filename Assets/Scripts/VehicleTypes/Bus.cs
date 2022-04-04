using UnityEngine;

// INHERITANCE
public class Bus : Vehicle
{
	private float _speed;

	private void OnEnable()
	{
		RandomizeSpeedAmount();
	}

	private void Update()
	{
		MoveForward(_speed);
	}

	private void RandomizeSpeedAmount()
	{
		_speed = Random.Range(45f, 60f);
	}
}
