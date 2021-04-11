using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

//change the name of class as well
public class SpawnManagerL2: MonoBehaviour
{
    [Header ("Rock: parameters")]
    [SerializeField] private float _delay = 1f;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private float _nextRock = -1f;
    [SerializeField] private float _rockRate = 0.85f;

    [Header("Lava: parameters")]
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private float _nextLava = -1f;
    [SerializeField] private float _lavaRate = 1f;

    //the mode that activates an infinite spawning; always true
    private bool _spawningON = true;
    

    void Start()
    {
        
    }
    
    void Update()
    {
        StartCoroutine(SpawnRockSystem());
        StartCoroutine(SpawnLavaSystem());
    }
    
    IEnumerator SpawnRockSystem()
    {
        while (_spawningON && Time.time > _nextRock) //condition
            //if while (true) creates the infinite loop
        {
            _nextRock = Time.time + _rockRate; 
            
            //CHANGE coordinates manually for every new position
            Instantiate(_rockPrefab, new Vector3(-9.80000019f,1f,-10.1599998f), Quaternion.identity);
           //wait for 2 seconds
           yield return new WaitForSeconds(_delay); 
        }
    }

    IEnumerator SpawnLavaSystem()
    {
        while (_spawningON && Time.time > _nextLava)
        {
            _nextLava = Time.time + _lavaRate;
            //CHANGE coordinates manually for every new position
            Instantiate(_lavaPrefab, new Vector3(2.47286224f,0.150000006f,2.04999995f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
