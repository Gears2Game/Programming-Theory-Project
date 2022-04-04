using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
	[SerializeField]private float _speed;
    private Vector3 _startPos;

	void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(-Vector3.left * Time.deltaTime * _speed);

        if (transform.position.z < _startPos.z / 4)
        {
            transform.position = _startPos;
        }
    }
}
