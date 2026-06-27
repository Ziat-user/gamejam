using UnityEngine;

public class Toycar : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        rb.AddForce(new Vector3(0f, 0f, 10.0f));
    }
}
