using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManagerL1 : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _delay = 1f;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private float _nextRock = -1f;
    [SerializeField] private float _rockRate = 1.5f;

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
            Instantiate(_rockPrefab, new Vector3(-9.8f, 1f, -10.16f), Quaternion.identity);
            //wait for 2 seconds
            yield return new WaitForSeconds(_delay);
        }
    }
}
