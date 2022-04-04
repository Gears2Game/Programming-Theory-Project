using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PickUp : Vehicle
{
	[SerializeField] private float _speed;

	private void Update()
	{
		MoveForward(_speed);
	}
}
