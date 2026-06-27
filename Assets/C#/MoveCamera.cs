using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public PlayerMove player;
    public Toycar toyCar;

    public float cameraPlayerHeight = 10.0f;
    public float cameraPlayerBack = -2.0f;
    
    public float cameraToyHeight = 10.0f;
    public float cameraToyBack = -2.0f;

    public TimerManager tm;

    void Start()
    {

    }
    void Update()
    {
        if (tm.isPlayer)
        {
            Vector3 cameraPlayerPos = player.transform.position;
            transform.LookAt(cameraPlayerPos);
            cameraPlayerPos.y += cameraPlayerHeight;
            cameraPlayerPos.z += cameraPlayerBack;
            transform.position = cameraPlayerPos;
            //Vector3 cameraAngle = new Vector3(90.0f, 0.0f, 0.0f);
            //transform.eulerAngles = cameraAngle;
        }

        if (tm.isToyCar)
        {
            Vector3 cameraToyPos = toyCar.transform.position;
            transform.LookAt(cameraToyPos);
            cameraToyPos.y += cameraToyHeight;
            cameraToyPos.z += cameraToyBack;
            transform.position = cameraToyPos;
        }
    }
}
