using UnityEngine;

// INHERITANCE
public class Van : Vehicle
{
	[SerializeField] private float _speed;

	private void Update()
	{
		MoveForward(_speed);
	}
}
