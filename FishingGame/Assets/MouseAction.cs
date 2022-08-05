using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction : MonoBehaviour {

    Vector2 Rot = Vector2.zero;
    public Vector2 Bias = new Vector2(5.0f, 5.0f); //��]���x
    public float maxPitch = 60.0f; //�p����
    public float minPitch = -60.0f; //��p����
    void Update() {
#if UNITY_EDITOR
        Rot.x = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Bias.x;
        Rot.y += Input.GetAxis("Mouse Y") * Bias.y;
        Rot.y = Mathf.Clamp(Rot.y, minPitch, maxPitch);
        transform.localEulerAngles = new Vector3(-Rot.y, Rot.x, 0);
#endif
    }
}
