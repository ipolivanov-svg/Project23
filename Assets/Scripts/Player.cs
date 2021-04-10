using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] 
    private float _speed = 2f;
    Rigidbody rb;
    
    [Header ("Jump Parameters")]
    public Vector3 jump;
    public float _jumpRate = 1f;
    private float _nextJump = 0.0f;
    public float _jumpForce = 0.8f;
    public bool _isGrounded;
    
    [Header ("Fire Parameters")]
    public float _nextFire = -1f;
    public float _fireRate = 0.5f;
    public GameObject _firePrefab;

    void Start()
    {
        //starting point
        transform.position = new Vector3(0f, 1f, 0f);
        
        //Jump settings
        rb = GetComponent<Rigidbody>(); //assigning Rigidbody component
        jump = new Vector3(0f, 8f, 0f);
        _jumpForce = 0.8f;
    }
    
    void Update()
    {
        PlayerMovement();
        Jump();
        Fire();
    }
    
    void PlayerMovement()
    {
        //read player input on x and y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //apply player movement
        main: transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * _speed * Time.deltaTime);
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * verticalInput);
        
        //setting the borders
        //on x axis
        if(transform.position.x >19.5f)
        {
            transform.position = new Vector3(19.5f,
                y: transform.position.y, z: transform.position.z);
        }
        else if(transform.position.x < -19.5f)
        {
            transform.position = new Vector3(-19.5f,
                y: transform.position.y, z: transform.position.z);
        }
        
        //on z axis
        else if(transform.position.z > 19.5f)
        {
            transform.position = new Vector3(transform.position.x,
                y: transform.position.y, z: 19.5f);
        }
        else if(transform.position.z < -19.5f)
        {
            transform.position = new Vector3(transform.position.x,
                y: transform.position.y, z: -19.5f);
        }
        
        //on y axis
        //so it won't fall down with the gravity on (need for jump)
        else if(transform.position.y < 1f)
        {
            transform.position = new Vector3(transform.position.x,
                y: 1f, z: transform.position.z);
        }
        //and it couldn't jump any higher
        else if (transform.position.y > 3f)
        {
            transform.position = new Vector3(transform.position.x,
                y: 3f, z: transform.position.z);
        }
    }
    
    void OnCollisionStay(){
        //creating a void that changes the bool
        //when the Player is on the ground isGrounded = true
        _isGrounded = true;
    }
    void Jump()
    {
        //creating a jump
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && Time.time > _nextJump)
        {
            rb.AddForce(jump * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
            //also checked the boxes on xyz axis in Freeze Rotation in Rigidbody
            //so it wouldn't rotate while jump
            _nextJump = Time.time + _jumpRate;
        }
    }

    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.P) && Time.time > _nextFire)
        {
            Debug.Log(message: "P pressed!"); //check
            _nextFire = Time.time + _fireRate;
            Instantiate(_firePrefab, transform.position + new Vector3(-0.1f, 1f, 0.5f),
                Quaternion.identity);
        }
    }
}
