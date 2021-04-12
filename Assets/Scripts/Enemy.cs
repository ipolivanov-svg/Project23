using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] 
    public int _healthEnemy = 3;

    void Start()
    {
    }
    
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if it collides with Player
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        //if it's Fire
        else if (other.CompareTag("Blast"))
        {
            /*Destroy(this.gameObject);*/
            Damage();
            Destroy(other.gameObject);
        }
    }
    
    public void Damage()
    {
        _healthEnemy -= 1;
        if (_healthEnemy == 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(10);
            Destroy(this.gameObject);
        }
    }
}
