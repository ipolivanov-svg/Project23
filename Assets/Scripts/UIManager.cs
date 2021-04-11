using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] 
    private Text _scoreText;
    
    void Start()
    {
        _scoreText.text = "Score: " + _score;
    }
    
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }
}
