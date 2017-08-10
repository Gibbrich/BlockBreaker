using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    
    // Use this for initialization
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
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
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }
}