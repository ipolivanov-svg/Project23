using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int _score = 0;
    
    [SerializeField] 
    private Text _scoreText;
    [SerializeField] 
    private Text _healthText;
    [SerializeField]
    private Text _gameOverText;
    
    private Player _player;
    
    void Start()
    {
        _scoreText.text = "Score: " + _score;
        _healthText.text = "Lives: 5";
        _gameOverText.gameObject.SetActive(false);
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
      //  _player._health += health; 
        _healthText.text = "Lives: " + health;
    }

    public void ShowGameOver()
    {
        _gameOverText.gameObject.SetActive(true);
    }
}
