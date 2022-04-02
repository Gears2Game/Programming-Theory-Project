using UnityEngine;

public class Vehicle : MonoBehaviour
{
	private Rigidbody _rigidBody;

	private void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	public void MoveForward(float speed)
	{
		_rigidBody.AddForce(Vector3.forward * -(speed + Random.Range(1f,10f)), ForceMode.Force);
	}

	public virtual void Avoid(float steerAmount)
	{
		_rigidBody.AddForce(Vector3.right * steerAmount, ForceMode.Impulse);
	}

	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.gameObject.CompareTag("Obstacle"))
	//	{
	//		Destroy(gameObject);
	//	}

	//	if (collision.gameObject.CompareTag("Player"))
	//	{
	//		Destroy(gameObject);
	//		GamePointHandler.Instance.GamePoint -= 1;
	//		print(GamePointHandler.Instance.GamePoint);
	//	}
	//}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
			GamePointHandler.Instance.GamePoint -= 1;
			print(GamePointHandler.Instance.GamePoint);
		}
	}
}