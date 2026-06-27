//----------------------------------------
// プレイヤーの移動
//----------------------------------------
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    //変数宣言
    public float playerSpeed = 1.0f;
    public Vector3 playerPos;
    public bool isPlayer = false;

    public TimerManager playTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーのポジションを今の現在地に
        playerPos =  transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //操作方法
        //wキー
        if (playTimer.isPlayer == true)
        {
            if (Keyboard.current.wKey.isPressed)
            {
                playerPos.z += playerSpeed * Time.deltaTime;
            }
            //sキー
            if (Keyboard.current.sKey.isPressed)
            {
                playerPos.z -= playerSpeed * Time.deltaTime;
            }
            //dキー
            if (Keyboard.current.dKey.isPressed)
            {
                playerPos.x += playerSpeed * Time.deltaTime;
            }
            //aキー
            if (Keyboard.current.aKey.isPressed)
            {
                playerPos.x -= playerSpeed * Time.deltaTime;
            }
            //値を反映させる
            transform.position = playerPos;
        }
    }
}
