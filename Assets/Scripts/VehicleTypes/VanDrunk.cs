using UnityEngine;

public class VanDrunk : Vehicle
{
	[SerializeField] private float _swervingTime = 1.5f;
	private float _speed;
	private float _lastswerve = 0f;
	private float _randomDirection;
	private float _steerAmount;

	private void OnEnable()
	{
		RandomizeDirection();
		RandomizeSteeringAmount();
		RandomizeSpeedAmount();
	}

	private void RandomizeDirection()
	{
		_randomDirection = Random.Range(0f, 2f);
	}

	private void RandomizeSteeringAmount()
	{
		_steerAmount = Random.Range(20f, 40f);
	}

	private void RandomizeSpeedAmount()
	{
		_speed = Random.Range(55f, 70f);
	}

	private void Update()
	{
		MoveForward(_speed);

		_lastswerve += Time.deltaTime;

		if (_lastswerve >= _swervingTime)
		{
			if (_randomDirection <= 1f)
			{
				Avoid(_steerAmount);
				_lastswerve = 0f;
				RandomizeSteeringAmount();
				RandomizeDirection();
			}
			else if(_randomDirection > 1f)
			{
				Avoid(-_steerAmount);
				_lastswerve = 0f;
				RandomizeSteeringAmount();
				RandomizeDirection();
			}
		}
				Debug.Log(_randomDirection);

	}

	 public override void Avoid(float steerAmount)
	 {
	 	base.Avoid(steerAmount);
	 }
}
