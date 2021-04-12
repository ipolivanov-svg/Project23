using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    private UIManager _uiManager;
    private bool _nearPrincess;
    
    void Start()
    {
    }
    
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You are near Princess");
            GameObject.FindWithTag("Player").GetComponent<Player>().StartMessage();
        }
    }
}
