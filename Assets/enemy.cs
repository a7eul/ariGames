using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform point;
    public Rigidbody body;
    public CharacterController characterController;
    public float speed = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<bullet>() != null)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        body.AddForce(transform.forward * speed);
        transform.LookAt(point);
        
    }
}
