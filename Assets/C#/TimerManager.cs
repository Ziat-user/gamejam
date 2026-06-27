// ****************************************************************************************************************
// ゲームタイマー管理用
// 
// ****************************************************************************************************************
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [Header("タイマー管理")]
    public float carLimitTimer;      // カー制限時間
    public float playerLimitTimer;   // プレイヤーー制限時間         
    public float limitTimer;         // 制限時間(処理で使う用)   
    public TextMeshProUGUI timerText;// タイマーテキスト
    float currentTime;               // 経過時間

    [Header("プレイヤー情報")]
    // スクリプト名 スクリプト名(小文字);
    public bool isPlayer;     // プレイヤーの使用フラグ

    [Header("カー情報")]
    // スクリプト名 スクリプト名(小文字);
    public bool isToyCar;     // カーの使用フラグ


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        limitTimer = carLimitTimer;
        currentTime = limitTimer;
        isToyCar = true;
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {

        // カー移動時間
        if (isToyCar)
        {
            // 時間計測
            CountTimer();

            if(currentTime <= 0)
            {
                // フラグオフ
                isToyCar = false;
                // フラグオン
                isPlayer = true;

                // タイマー切り替え
                SwitchTimer();
            }
        }

        // カー移動時間
        //if (isPlayer)
        //{
        //    // 時間計測
        //    CountTimer();
        //
        //    if (currentTime <= 0)
        //    {
        //        // フラグオフ
        //        isPlayer = false;
        //        // フラグオン
        //        isToyCar = true;
        //
        //        SwitchTimer();
        //    }
        //}

        // 時間表示
        TimerText();
    }

    //*****************************************************************************
    // 時間計測関数
    //*****************************************************************************
    void CountTimer()
    {
        currentTime -= Time.deltaTime;
    }

    //*****************************************************************************
    // 時間表示関数
    //*****************************************************************************
    void TimerText()
    {
        int seconds = (int)(currentTime % 60f);

        timerText.text = seconds.ToString();
    }

    //*****************************************************************************
    // 時間切り替え関数
    //*****************************************************************************
    void SwitchTimer()
    {
        if(isPlayer)
        {
            Debug.Log("プレイヤー時間に切り替わりました");
            limitTimer = playerLimitTimer;
            currentTime = limitTimer;
        }
        else if(isToyCar)
        {
            Debug.Log("カー時間に切り替わりました");
            limitTimer = carLimitTimer;
            currentTime = limitTimer;
        }

    }
}
