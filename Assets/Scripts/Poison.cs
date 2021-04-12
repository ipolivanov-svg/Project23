using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poison : MonoBehaviour
{
    [Header("Characteristics")] 
    [SerializeField]
    private float _speedPoison = 5f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.back * _speedPoison * Time.deltaTime);
        //destroyed
        //on z axis
        if(transform.position.z < -11.99f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if it collides with Player
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
        }
        
        //if it's Fire - nothing happens
        //both Fire and Poison are still present
        
        else if (other.CompareTag("Surroundings"))
        {
            Destroy(this.gameObject);
        }
    }
}
