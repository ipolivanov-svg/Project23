using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    private Player _player;
    
    void Start()
    {
        _score = PlayerPrefs.GetInt("Score", 0);
        _health = PlayerPrefs.GetInt("Lives", 5);
        _scoreText.text = "Score: " + _score;
        _healthText.text = "Lives: " + _health;
        _gameOverText.gameObject.SetActive(false);
        _gunFireText.gameObject.SetActive(false);
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
    
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.SetInt("Lives:", _health);
    }
}
