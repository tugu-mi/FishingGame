using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //uGUI�̗��p�ɕK�v

public class MenuAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CollBeem")
        {
            //���j���[�Ƀr�[�����N�����āA�������ɂȂ�
            GetComponent<Image>().color *= new Color(1, 1, 1, 0.5f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CollBeem")
        {
            //���j���[����r�[�����O��A���S�s�����ɖ߂�
            GetComponent<Image>().color += new Color(0, 0, 0, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
