using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public PlayerMove player;
    public Toycar toyCar;

    public float cameraHeight = 10.0f;
    public float cameraBack = -2.0f;


    void Start()
    {

    }
    void Update()
    {
        if (player.GetFlag)
        {
            Vector3 cameraPlayerPos = player.transform.position;
            cameraPlayerPos.y += cameraHeight;
            cameraPlayerPos.z += cameraBack;
        }

        if (toyCar.GetFlag)
        {
            Vector3 cameraToyPos = toyCar.transform.position;

        }
    }
}
