using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Characteristics")] 
    [SerializeField]
    private float _speedFire = 4f;
    [SerializeField]
    private GameObject _parent;
    void Update()
    {
        Movement();
        SetParent();
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * _speedFire * Time.deltaTime);
        
        //destroyed
        //on z axis
        if(transform.position.z > 19.5f)
        {
            Destroy(this.gameObject);
        }
        else if(transform.position.z < -19.5f)
        {
            Destroy(this.gameObject);
        }
    }

//TODO: надо сделать так, чтобы у всех копий новых Fire был Blast as a parent
//этот код не работает
    void SetParent()
    {
        _parent.transform.parent = this.gameObject.transform;
    }
}
