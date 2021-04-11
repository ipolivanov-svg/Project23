using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] 
    private Text _scoreText;

    private int _health = 5;
    [SerializeField] 
    private Text _healthText;
    
    void Start()
    {
        _scoreText.text = "Score: " + _score;
        _healthText.text = "Lives: " + _health;
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
        _health += health; 
        _healthText.text = "Lives: " + _health;
    }
}
