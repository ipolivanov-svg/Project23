using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    private Player _player;
    
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
            GameObject.FindWithTag("Player").GetComponent<Player>().ActivatePowerUp();
            Destroy(this.gameObject);
        }
    }
}
