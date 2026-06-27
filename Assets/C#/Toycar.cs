using UnityEngine;

public class Toycar : MonoBehaviour
{
    public float forceMagnitude = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.0f, 0.0f, 10.0f), ForceMode.Force);
    }

    // •¨—‰‰ZiAddForcej‚Í FixedUpdate ‚É‚¨ˆø‰z‚µ
    void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
