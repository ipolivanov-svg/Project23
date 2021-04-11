using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [Header("Parameters")] [SerializeField]
    private float _lavaSpeed = 1f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Movement();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayHealth(-1);
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _lavaSpeed);

        if (transform.position.y > 0.2f)
        {
            Destroy(this.gameObject);
        }
    }

}
