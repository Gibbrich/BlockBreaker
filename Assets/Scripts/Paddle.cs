using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float mouseBlockPositionX = Input.mousePosition.x / Screen.width * 16;
        float paddlePositionX = Mathf.Clamp(mouseBlockPositionX, 0.5f, 15.5f);
        transform.position = new Vector3(paddlePositionX, transform.position.y);
    }
}