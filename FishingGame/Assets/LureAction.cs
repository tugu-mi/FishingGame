using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureAction : MonoBehaviour {

    Rigidbody myRB; //自身のリジッドボディ
    CharacterJoint myCJ; //自身のキャラクタージョイント
    TrailRenderer myTR; //自身のトレイルレンダラー
    GameObject RodTip; //ロッドのティップ（穂先）
    public GameObject SplashEffect; //水しぶきエフェクト
    public float SplashLife = 1.5f; //水しぶきの寿命
    public float ThrownPower = 0.3f; //投げる力

    void Start() {
        myRB = GetComponent<Rigidbody>(); //自身のリジッドボディを取得
        myTR = GetComponent<TrailRenderer>(); //自身のトレイルレンダラーを取得
        myTR.enabled = false; //自身のトレイルレンダラーを非表示

        //自分でロッドのティップを見つけてぶら下がる
        RodTip = GameObject.Find("joint10");
        myCJ = GetComponent <CharacterJoint>();
        myCJ.connectedBody = RodTip.GetComponent<Rigidbody>();
    }

    void Thrown( Vector3 Dir ) {
        Destroy( myCJ ); //キャラクタージョイントを切る
        myRB.useGravity = true; //重力の影響開始
        myTR.enabled = true; //トレイルレンダラーを表示

        if ( Dir.sqrMagnitude > 0.05f ) {
            //瞬間ベクトルが十分な長さなら、その方向へ飛ばす
            myRB.AddForce(Dir * ThrownPower, ForceMode.Impulse); 
        }
    }


    void Update() {
        //自身が水面下以下なら撤去
        if (transform.position.y < 0.0f) {
            //水しぶきもっていれば生成と撤去の予約
            if (SplashEffect) {
                GameObject Fx = Instantiate(SplashEffect,transform.position,Quaternion.identity);
                Destroy(Fx, SplashLife);
            }
            Destroy(gameObject);
        }
    }
}
