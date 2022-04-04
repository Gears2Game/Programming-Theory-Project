using UnityEngine;
// INHERITANCE
public class DrunkVehicle : Vehicle
{
	private float _swervingTime;
	private float _speed;
	private float _lastswerve = 0f;
	private float _randomDirection;
	private float _steerAmount;

	private void OnEnable()
	{
		// ABSTRACTION
		RandomizeBehaviour();
		RandomizeSpeedAmount();
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
				RandomizeBehaviour();
			}
			else if (_randomDirection > 1f)
			{
				Avoid(-_steerAmount);
				_lastswerve = 0f;
				RandomizeBehaviour();
			}
		}
	}

	// POLYMORPHISM
	public override void Avoid(float steerAmount)
	{
		base.Avoid(steerAmount); // override steeramount with a randomized value
	}

	private void RandomizeBehaviour()
	{
		_randomDirection = Random.Range(0f, 2f);
		_steerAmount = Random.Range(20f, 40f);
		_swervingTime = Random.Range(1f, 2f);
	}

	private void RandomizeSpeedAmount()
	{
		_speed = Random.Range(55f, 70f);
	}

}
