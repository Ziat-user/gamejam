using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Toycar : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField]
    private float moveSpeed = 5f;

    [Header("初期移動方向")]
    [SerializeField]
    private Vector3 initialDirection = Vector3.forward;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float fixedY;

    public bool isToyCar = false;

    public TimerManager toyTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Y軸方向の移動と、物理衝突による不要な回転を防ぐ
        rb.constraints =
            RigidbodyConstraints.FreezePositionY |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;

        // 重力で沈んだり跳ねたりしないようにする
        rb.useGravity = false;

        // 物理演算で移動するため
        rb.isKinematic = false;

        // 衝突判定を安定させる
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Start()
    {
        fixedY = transform.position.y;

        moveDirection = initialDirection;
        moveDirection.y = 0f;

        if (moveDirection == Vector3.zero)
        {
            moveDirection = Vector3.forward;
        }

        moveDirection.Normalize();
    }

    private void FixedUpdate()
    {
        if(toyTimer.isToyCar == true)
        {
            Vector3 currentPosition = rb.position;

            // Y座標を常に固定
            currentPosition.y = fixedY;

            Vector3 nextPosition = currentPosition + moveDirection * moveSpeed * Time.fixedDeltaTime;
            nextPosition.y = fixedY;

            rb.MovePosition(nextPosition);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;

        // 地面など、タグ object のものには反射しない
        if (hitObject.CompareTag("ground"))
        {
            return;
        }

        // タグがついていない壁などに当たったら反射
        ReflectDirection(collision);
    }

    private void ReflectDirection(Collision collision)
    {
        if (collision.contactCount == 0)
        {
            return;
        }

        Vector3 normal = collision.contacts[0].normal;

        // Y方向の成分を消して、XZ平面上だけで反射する
        normal.y = 0f;

        if (normal == Vector3.zero)
        {
            return;
        }

        normal.Normalize();

        moveDirection = Vector3.Reflect(moveDirection, normal);
        moveDirection.y = 0f;
        moveDirection.Normalize();

        // 念のためY座標を戻す
        Vector3 correctedPosition = rb.position;
        correctedPosition.y = fixedY;
        rb.position = correctedPosition;
    }
}
