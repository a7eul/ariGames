using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    public Transform pos;
    float xRotation = 0f;
    public GameObject bullet;
    public Transform point;
    void Start()
    {
       
    }
    void Update()
    {
        float s = Input.GetAxis("Mouse X");
        Debug.Log(s);
        Transform r = Camera.main.transform;
        pos.Rotate(0, Input.GetAxis("Mouse X") * 2, 0);
        rb.velocity = (pos.forward * Input.GetAxis("Vertical") + pos.right * Input.GetAxis("Horizontal")) * 40;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        float mouseY = Input.GetAxis("Mouse Y") * 2;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        r.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, point.position, Quaternion.identity);
        }
    }
}
