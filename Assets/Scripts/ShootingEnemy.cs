using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f,0f,0f);
    }

    void Update()
    {
    }


    void OnTriggerEnter(Collider other)
    {
        //if the object we collide with is the player
        if (other.CompareTag("Player"))
        {
            //damage player or destroy it
            other.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
        }
        //but if the other one is vaccine
        else if (other.CompareTag("Enemy"))
        {
            //destroy vaccine and the virus
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
