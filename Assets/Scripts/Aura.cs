using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    [Header ("Poison Parameters")]
    public float _nextPoison = -1f;
    public float _poisonRate = 0.3f;
    [SerializeField]
    private GameObject _poisonPrefab;
    
    [SerializeField]
    private GameObject _theEnemy;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if it collides with Player
        if (other.CompareTag("Player") && Time.time > _nextPoison)
        {
            _nextPoison = Time.time + _poisonRate;
            Instantiate(_poisonPrefab,
                _theEnemy.transform.position + new Vector3(0.111526698f,0.283886373f,-0.547495186f),
                 Quaternion.identity);
        }
    }
}
