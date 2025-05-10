using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody a;
    public Transform pos;
    float xRotation = 0f;
    public GameObject bullet;
    public Transform point;
    private bool isGrounded;
    void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(0, 200, 0));
    }
    void Update()
    {
        float s = Input.GetAxis("Mouse X");
        Debug.Log(s);
        Transform r = Camera.main.transform;
        pos.Rotate(0, Input.GetAxis("Mouse X") * 2, 0);
        rb.velocity = (pos.forward * Input.GetAxis("Vertical") + pos.right * Input.GetAxis("Horizontal")) * 40 + new Vector3(0, rb.velocity.y, 0); 

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        float mouseY = Input.GetAxis("Mouse Y") * 2;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        r.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
   
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody a = Instantiate(bullet, point.position, point.rotation).GetComponent<Rigidbody>();
            float bulletSpeed = 200f;
            a.velocity = a.transform.forward * bulletSpeed;
        }  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 500, 0));
        }
    }
}
