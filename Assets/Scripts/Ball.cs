using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float Ball_speed = 15f;
    private Vector3 Move_direction;
    private Vector3 defaultPosition = new Vector3(0,0.45f,0);

    
    void  Start()
    {
        float x_random_direction;
        float z_random_direction;

        x_random_direction = Random.Range(-2f,2f);
        z_random_direction = Random.Range(-1f,1f);

        Move_direction = new Vector3(x_random_direction, 0, z_random_direction).normalized;
    }

    
    void Update()
    {
        gameObject.transform.position += Move_direction * Time.deltaTime * Ball_speed;
    }

    void OnCollisionEnter(Collision other)
    {
        Move_direction = Vector3.Reflect(Move_direction,other.contacts[0].normal);

        if (other.gameObject.tag == "Left Wall")
        {
            Score.rightPlayerScore++;
            gameObject.transform.position = defaultPosition;
        }
        if (other.gameObject.tag == "Right Wall")
        {
            Score.leftPlayerScore++;
            gameObject.transform.position = defaultPosition;
        }


    }
}
