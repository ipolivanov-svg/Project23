using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManagerL3 : MonoBehaviour
{
    [Header ("Rock: parameters")]
    [SerializeField] private float _delay = 1f;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private GameObject _rockParent;
    [SerializeField] private float _nextRock = -1f;
    [SerializeField] private float _rockRate = 0.85f;

    [Header("Lava: parameters")]
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private GameObject _lavaParent;
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
        while (_spawningON && Time.time > _nextRock) 
        {
            _nextRock = Time.time + _rockRate; 
            
            //CHANGE coordinates manually for every new position
            Instantiate(_rockPrefab, new Vector3(-17f,1f,3f), Quaternion.identity, transform.parent = _rockParent.transform);
            yield return new WaitForSeconds(_delay); 
        }
    }

    IEnumerator SpawnLavaSystem()
    {
        while (_spawningON && Time.time > _nextLava)
        {
            _nextLava = Time.time + _lavaRate;
            //CHANGE coordinates manually for every new position
            Instantiate(_lavaPrefab, new Vector3(6.09f,0.01f,10.69f), Quaternion.identity, transform.parent = _lavaParent.transform);
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
