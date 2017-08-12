using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool AutoPlay = false;

    private Ball ball;
    // Use this for initialization
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AutoPlay)
        {
            MoveAuto();
        }
        else
        {
            MoveWithMouse();
        }
    }

    private void MoveAuto()
    {
        float paddlePositionX = Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f);
        transform.position = new Vector3(paddlePositionX, transform.position.y);
    }

    private void MoveWithMouse()
    {
        float mouseBlockPositionX = Input.mousePosition.x / Screen.width * 16;
        float paddlePositionX = Mathf.Clamp(mouseBlockPositionX, 0.5f, 15.5f);
        transform.position = new Vector3(paddlePositionX, transform.position.y);
    }
}