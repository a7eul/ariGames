using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform Player;
    public CharacterController characterController;
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

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position,3f);
    }
}
