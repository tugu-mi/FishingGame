using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //uGUIの利用に必要

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
            //メニューにビームが侵入して、半透明になる
            GetComponent<Image>().color *= new Color(1, 1, 1, 0.5f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CollBeem")
        {
            //メニューからビームが外れ、完全不透明に戻る
            GetComponent<Image>().color += new Color(0, 0, 0, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
