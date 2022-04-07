using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public int PowerUpAmount { get; private set; }
    public bool IsGameOver { get; private set; }

    private int _powerUpAmount = 3;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private TMP_Text _powerAmountText;
    [SerializeField] private Button _restartGameButton;

	private void Awake()
	{
        IsGameOver = false;
	}

	private void Start()
    {
        PowerUpAmount = _powerUpAmount;
        _gameOverText.SetActive(false);
        _restartGameButton.gameObject.SetActive(false);
        DisplayPowerAmount();
    }

    private void Update()
    {
        if (PowerUpAmount <= 0)
		{
			CheckIfGameOver();
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

			foreach (var enemy in enemies)
			{
				enemy.GetComponent<Transform>().gameObject.SetActive(false);
			}
		}
	}

	private void CheckIfGameOver()
	{
		IsGameOver = true;
		_gameOverText.SetActive(true);
		_restartGameButton.gameObject.SetActive(true);
	}

	private void DisplayPowerAmount()
    {
        _powerAmountText.text = PowerUpAmount.ToString();
    }

    public void ReducePowerUpAmount()
    {
        PowerUpAmount--;
        DisplayPowerAmount();
    }

    public void IncreasePowerUpAmount()
    {
        PowerUpAmount++;
        DisplayPowerAmount();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
