using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManager : MonoBehaviour
{
    [Header ("Parameters")]
    [SerializeField] private float _delay = 1f;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private float _nextRock = -1f;
    [SerializeField] private float _rockRate = 0.85f;
    
    //the mode that activates an infinite spawning; always true
    private bool _spawningON = true;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        StartCoroutine(SpawnSystem());
    }
    
    IEnumerator SpawnSystem()
    {
        while (_spawningON && Time.time > _nextRock) //condition
            //if while (true) creates the infinite loop
        {
            _nextRock = Time.time + _rockRate; 
    //TODO: я пока хз, что делать с координатами - они фиксированные, для каждой точки придется вручную менять       
            Instantiate(_rockPrefab, new Vector3(-17f,1f,3f), Quaternion.identity);
           //wait for 2 seconds
           yield return new WaitForSeconds(_delay); 
        }
    }
}
