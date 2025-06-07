using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 1;
    public float angleSpeed = 1;
    public static bool isGraund = true;
    public Transform wheel_left, wheel_right;
    void Update()
    {
        Roll();
        Ray under = new Ray(transform.position + new Vector3(0, 0.6f, 0), -transform.up);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(under, out hit))
        {

            if (hit.distance > 5.1)
            {
                isGraund = false;
            }
            else
            {
                isGraund = true;
            }
            Debug.Log(hit.distance);
        }
        Debug.Log(isGraund);
        if (isGraund)
        {
            Move();
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed);
            wheel_left.rotation = Quaternion.Euler(transform.up * Input.GetAxis("Horizontal") * 60);
            wheel_right.rotation = Quaternion.Euler(transform.up * Input.GetAxis("Horizontal") * 60);
        }
        if (Input.GetKey(KeyCode.S))
        {
            {
                rb.AddForce(transform.forward * -speed);
                wheel_left.rotation = Quaternion.Euler(transform.up * Input.GetAxis("Horizontal") * -60);
                wheel_right.rotation = Quaternion.Euler(transform.up * Input.GetAxis("Horizontal") * -60);
            }
        }
    }
    void Roll()
    {
        Ray left = new Ray(transform.position + new Vector3(0, 40, 0), -transform.right);
        Ray right = new Ray(transform.position + new Vector3(0, 40, 0), transform.right);

        RaycastHit hit_left = new RaycastHit();
        RaycastHit hit_right = new RaycastHit();

        if (Physics.Raycast(left, out hit_left))
        {
            if (hit_left.distance < 2)
            {
                rb.AddTorque(-transform.forward * 10000);
                Debug.Log(hit_left.distance);
            }
            Debug.DrawRay(transform.position + new Vector3(0,1,0), - transform.right * 4,Color.blue,4);
        }
        if (Physics.Raycast(left, out hit_right))
        {
            if (hit_right.distance < 2)
            {
                rb.AddTorque(-transform.forward * 10000);
                Debug.Log(hit_right.distance);
            }
            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.right * 4, Color.red, 4);
        }
    }
}