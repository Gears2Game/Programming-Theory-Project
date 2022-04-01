using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _enemies;
    public GameObject _powerUp;

    private float _xRange = 20f;
    private float _zRangePowerUp = 8.0f;
	private float _spawnDelay = 1.0f;
	private float _spawnIntervalPowerUp = 20.0f;

	private float _enemySpawnPos = 80f;
	private float _spawnIntervalEnemies = 2.5f;

    void Start()
	{
		InvokeRepeating("SpawnPowerUp", _spawnDelay, _spawnIntervalPowerUp);
		InvokeRepeating("SpawnEnemy", _spawnDelay, _spawnIntervalEnemies);
	}

	void Update()
	{

	}

	private void SpawnPowerUp()
	{
		float randomPowerUpSpawnRangeZ = Random.Range(-_zRangePowerUp, _zRangePowerUp);
		float randomPositionRangeX = Random.Range(-_xRange, _xRange);
		Vector3 randomPowerUpPosition = new Vector3(randomPositionRangeX, _powerUp.gameObject.transform.position.y, randomPowerUpSpawnRangeZ);

		Instantiate(_powerUp, randomPowerUpPosition, _powerUp.gameObject.transform.rotation);
	}

	private void SpawnEnemy()
	{
		int randomIndex = Random.Range(0, _enemies.Length);
		float randomPositionRangeX = Random.Range(-_xRange, _xRange);

		Vector3 randomEnemyPosition = new Vector3(randomPositionRangeX, _enemies[randomIndex].gameObject.transform.position.y, _enemySpawnPos);

		Instantiate(_enemies[randomIndex], randomEnemyPosition, _enemies[randomIndex].gameObject.transform.rotation);
	}
}
