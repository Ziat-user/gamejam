using UnityEngine;

public class Toycar : MonoBehaviour
{
    public float forceMagnitude = 10f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        Vector3 forwardDirection = this.transform.forward;

        rb.AddForce(forwardDirection * forceMagnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 newVector;
        newVector = transform.eulerAngles;
        newVector.y += 90.0f;
        this.transform.eulerAngles = newVector;
    }
}
