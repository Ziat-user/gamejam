using UnityEngine;

public class Toycar : MonoBehaviour
{
    public float forceMagnitude = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 物理演算（AddForce）は FixedUpdate にお引越し
    void FixedUpdate()
    {
        Vector3 forwardDirection = this.transform.forward;
        rb.AddForce(forwardDirection * forceMagnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 地面なら何もしない（早期リターン）
        if (other.gameObject.CompareTag("ground")) return;

        // Y軸（上向きの軸）を中心に90度回転させる
        // 面倒な Vector3 への代入をスキップして1行で書けます
        this.transform.Rotate(0f, 90f, 0f);
    }
}
