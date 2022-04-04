using UnityEngine;

public class GamePointHandler : MonoBehaviour
{
	private static GamePointHandler _instance;

	public static GamePointHandler Instance
	{
		get
		{
			if (_instance == null)
			{
				print("GAME POINT HANDLER IS NULL");
			}

			return _instance;
		}
	}

	public int GamePoint;

	private void Awake()
	{
		_instance = this;
	}

	void Start()
    {
        GamePoint = 10;
    }
}
