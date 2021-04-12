using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int _score = 0;
    public int _health = 5;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _healthText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _gunFireText;
    [SerializeField] 
    private Text _finishWinText;
    [SerializeField] 
    private Text _finishLoseText;
    
    private Player _player;

    void Start()
    {
        _score = PlayerPrefs.GetInt("Score", 0);
        _health = PlayerPrefs.GetInt("Lives", 5);
        _scoreText.text = "Score: " + _score;
        _healthText.text = "Lives: " + _health;
        _gameOverText.gameObject.SetActive(false);
        _finishWinText.gameObject.SetActive(false);
        _finishLoseText.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateHealth(int health)
    {
        _healthText.text = "Lives: " + health;
    }

    public void ShowGameOver()
    {
        _gameOverText.gameObject.SetActive(true);
    }

    public void ShowGunFire()
    {
        _gunFireText.gameObject.SetActive(true);
    }

    public void FinishWin()
    {
        _finishWinText.gameObject.SetActive(true);
    }

    public void FinishLose()
    {
        _finishLoseText.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.SetInt("Lives:", _health);
    }
}
