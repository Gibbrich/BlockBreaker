using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle Paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    
    // Use this for initialization
    void Start()
    {
        paddleToBallVector = transform.position - Paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            transform.position = paddleToBallVector + Paddle.transform.position;
            
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }
}