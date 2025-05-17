using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public TrailRenderer trail;
    private AudioSource audioSource;
    public AudioClip goalSound;
    public AudioClip paddleHitSound;
    public GameObject goalParticlePrefab;
    private float Ball_speed = 15f;
    private Vector3 Move_direction;
    private Rigidbody rb;
    private Vector3 defaultPosition = new Vector3(0,0.45f,0);
    private bool isMoving = true;


    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = true;

        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;


        float x_random_direction;
        float z_random_direction;

        x_random_direction = Random.Range(-2f, 2f);
        z_random_direction = Random.Range(-1f, 1f);

        Move_direction = new Vector3(x_random_direction, 0, z_random_direction).normalized;

        rb.velocity = Move_direction * Ball_speed;
    }



    void Update()
    {
        if (isMoving)
        {
            rb.velocity = Move_direction * Ball_speed;

            Vector3 torqueDirection = Vector3.Cross(Vector3.up, Move_direction);
            rb.AddTorque(torqueDirection * Ball_speed, ForceMode.Force);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            audioSource.PlayOneShot(paddleHitSound);
        }

        if (other.gameObject.tag == "Left Wall")
        {
            audioSource.PlayOneShot(goalSound);
            Score.rightPlayerScore++;
            StartCoroutine(ResetBallAfterGoal());
        }
        else if (other.gameObject.tag == "Right Wall")
        {
            audioSource.PlayOneShot(goalSound);
            Score.leftPlayerScore++;
            StartCoroutine(ResetBallAfterGoal());
        }
        else
        {
            Move_direction = Vector3.Reflect(Move_direction, other.contacts[0].normal);
        }
    }


    IEnumerator ResetBallAfterGoal()
    {
        isMoving = false;
        rb.velocity = Vector3.zero;

        GameObject particle = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        Destroy(particle, 1f);

        yield return new WaitForSeconds(1f);

        transform.position = defaultPosition;

        float x_random_direction = Random.Range(-2f, 2f);
        float z_random_direction = Random.Range(-1f, 1f);
        Move_direction = new Vector3(x_random_direction, 0, z_random_direction).normalized;

        isMoving = true;
        rb.velocity = Move_direction * Ball_speed;
    }





}
