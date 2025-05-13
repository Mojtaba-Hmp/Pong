using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{   
    private float speed = 8f;
    private float Max_Z = 2f;
    private float Min_Z = -4.6f;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.z < Max_Z)
        {
            gameObject.transform.Translate(0, speed * Time.deltaTime,0);
        }

        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.z > Min_Z)
        {
            gameObject.transform.Translate(0, -speed * Time.deltaTime,0);
        }
    }
}
