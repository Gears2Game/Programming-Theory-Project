using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Rigidbody _enemyRb;
    private float _zDestroy = -12f;

    public float _speed = 5.0f;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
    }

	void Update()
	{
		_enemyRb.AddForce(Vector3.forward * -_speed);

        if (gameObject.transform.position.z < _zDestroy)
        {
            Destroy(gameObject);
        }
	}
}
