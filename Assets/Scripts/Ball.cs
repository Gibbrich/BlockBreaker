using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted;
    private AudioSource audioSource;
    private Rigidbody2D rigidbody;
    
    // Use this for initialization
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            transform.position = paddleToBallVector + paddle.transform.position;
            
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                rigidbody.velocity = new Vector2(2f, 10f);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        
        if (hasStarted)
        {
            audioSource.Play();
            
            print(rigidbody.velocity);
            rigidbody.velocity += tweak;
        }
    }
}