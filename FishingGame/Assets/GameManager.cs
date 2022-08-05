using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public enum MODE
    {
        TITLE,
        PLAY,
        TIMEUP,
        CLEAR
    }
    public MODE GameMode; //ゲームの状態


    public Image imgBtnA; //ボタンA画像
    public GameObject[] LurePrefab; //ルアープレハブ
    GameObject Lure; //生成したルアー
    Vector3 EscLurePos; //ルアー座標の退避エリア
    float Elapsed = 0.0f; //経過時間
    float EscInterval = 0.05f; //退避間隔

    float GameElapsed = 0.0f; //ゲーム経過時間

    public int StartHours = 5; //開始時間　時
    public int StartMinutes = 0; //開始時間　分
    public int LimitTime = 15; //制限時間
    public Text txtTime;

    void Start() {
        Ready();
    }

    //準備処理
    void Ready()
    {
        GameMode = MODE.TITLE;
        Elapsed = 0.0f; //ゼロクリア
        txtTime.text = StartHours + ":" + StartMinutes.ToString("d2");
    }

    void Update() {

        if (Lure == null) {

            //ルアーがない

            imgBtnA.enabled = true; //Aボタン画像を表示
            if (OVRInput.GetDown(OVRInput.RawButton.A) ) {
                //Ａ押下でルアーを生成
                Lure = Instantiate(LurePrefab[0]);
                imgBtnA.enabled = false; //Aボタン画像は不要
            }
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.Space))
            {
                //Ａ押下でルアーを生成
                Lure = Instantiate(LurePrefab[0]);
                imgBtnA.enabled = false; //Aボタン画像は不要
            }
#endif
        } else {

            //ルアーがある

            Elapsed += Time.deltaTime;
            if (Elapsed > EscInterval) {
                //ルアー存在なら退避間隔で位置を更新
                EscLurePos = Lure.transform.position;
                Elapsed = 0.0f;
            }

            //右トリガーをリリース時、ベクトル方向に飛ばす。
            if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) {
                Vector3 Dir = Lure.transform.position - EscLurePos;
                Lure.SendMessage("Thrown",Dir); 
            }
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.Return))
            {
                Vector3 Dir = Lure.transform.position - EscLurePos;
                Lure.SendMessage("Thrown", Dir);
            }
#endif
        }
    }
}
