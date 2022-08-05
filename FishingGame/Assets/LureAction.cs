using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureAction : MonoBehaviour {

    Rigidbody myRB; //���g�̃��W�b�h�{�f�B
    CharacterJoint myCJ; //���g�̃L�����N�^�[�W���C���g
    TrailRenderer myTR; //���g�̃g���C�������_���[
    GameObject RodTip; //���b�h�̃e�B�b�v�i���j
    public GameObject SplashEffect; //�����Ԃ��G�t�F�N�g
    public float SplashLife = 1.5f; //�����Ԃ��̎���
    public float ThrownPower = 0.3f; //�������

    void Start() {
        myRB = GetComponent<Rigidbody>(); //���g�̃��W�b�h�{�f�B���擾
        myTR = GetComponent<TrailRenderer>(); //���g�̃g���C�������_���[���擾
        myTR.enabled = false; //���g�̃g���C�������_���[���\��

        //�����Ń��b�h�̃e�B�b�v�������ĂԂ牺����
        RodTip = GameObject.Find("joint10");
        myCJ = GetComponent <CharacterJoint>();
        myCJ.connectedBody = RodTip.GetComponent<Rigidbody>();
    }

    void Thrown( Vector3 Dir ) {
        Destroy( myCJ ); //�L�����N�^�[�W���C���g��؂�
        myRB.useGravity = true; //�d�͂̉e���J�n
        myTR.enabled = true; //�g���C�������_���[��\��

        if ( Dir.sqrMagnitude > 0.05f ) {
            //�u�ԃx�N�g�����\���Ȓ����Ȃ�A���̕����֔�΂�
            myRB.AddForce(Dir * ThrownPower, ForceMode.Impulse); 
        }
    }


    void Update() {
        //���g�����ʉ��ȉ��Ȃ�P��
        if (transform.position.y < 0.0f) {
            //�����Ԃ������Ă���ΐ����ƓP���̗\��
            if (SplashEffect) {
                GameObject Fx = Instantiate(SplashEffect,transform.position,Quaternion.identity);
                Destroy(Fx, SplashLife);
            }
            Destroy(gameObject);
        }
    }
}
