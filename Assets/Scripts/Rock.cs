using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Rock : MonoBehaviour
{
    [Header("Characteristics")] 
    [SerializeField]
    private float _speed = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //movement only in the right direction
    void Movement()
    {
        //TODO: add rotation
        
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        //setting the borders
        //TODO: возможно надо подумать, как сделать посимпатичнее этот момент
        
        if(transform.position.x >19.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if it collides with Player
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        //if it's Fire
        else if (other.CompareTag("Blast"))
        {
            if (other.name.Contains("Fire"))
            { //destroys the vaccine if only it's not UV
                Destroy(this.gameObject);
            }
            //TODO: думала сделать еще вариант плеваться кислотой, от которой камню урона нет
            
            //in both conditions blast is gone after collision
            Destroy(other.gameObject);
            
        }
    }
}
