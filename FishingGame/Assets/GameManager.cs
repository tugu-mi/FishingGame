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
    public MODE GameMode; //�Q�[���̏��


    public Image imgBtnA; //�{�^��A�摜
    public GameObject[] LurePrefab; //���A�[�v���n�u
    GameObject Lure; //�����������A�[
    Vector3 EscLurePos; //���A�[���W�̑ޔ��G���A
    float Elapsed = 0.0f; //�o�ߎ���
    float EscInterval = 0.05f; //�ޔ��Ԋu

    float GameElapsed = 0.0f; //�Q�[���o�ߎ���

    public int StartHours = 5; //�J�n���ԁ@��
    public int StartMinutes = 0; //�J�n���ԁ@��
    public int LimitTime = 15; //��������
    public Text txtTime;

    void Start() {
        Ready();
    }

    //��������
    void Ready()
    {
        GameMode = MODE.TITLE;
        Elapsed = 0.0f; //�[���N���A
        txtTime.text = StartHours + ":" + StartMinutes.ToString("d2");
    }

    void Update() {

        if (Lure == null) {

            //���A�[���Ȃ�

            imgBtnA.enabled = true; //A�{�^���摜��\��
            if (OVRInput.GetDown(OVRInput.RawButton.A) ) {
                //�`�����Ń��A�[�𐶐�
                Lure = Instantiate(LurePrefab[0]);
                imgBtnA.enabled = false; //A�{�^���摜�͕s�v
            }
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.Space))
            {
                //�`�����Ń��A�[�𐶐�
                Lure = Instantiate(LurePrefab[0]);
                imgBtnA.enabled = false; //A�{�^���摜�͕s�v
            }
#endif
        } else {

            //���A�[������

            Elapsed += Time.deltaTime;
            if (Elapsed > EscInterval) {
                //���A�[���݂Ȃ�ޔ��Ԋu�ňʒu���X�V
                EscLurePos = Lure.transform.position;
                Elapsed = 0.0f;
            }

            //�E�g���K�[�������[�X���A�x�N�g�������ɔ�΂��B
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
