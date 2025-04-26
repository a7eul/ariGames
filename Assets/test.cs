using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    public Transform pos;
    void Start()
    {
        Vector3 dir = new Vector3(0,100,0);
        pos.Translate(dir);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rb.AddForce(new Vector3(150, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-150, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1000, 0));
        }
    }
}
