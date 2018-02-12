using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {
    public bool autoplay = false;
    public float minX;
    public float maxX;

    private ball Ball;

    // Use this for initialization
    void Start()
    {
        Ball = GameObject.FindObjectOfType<ball>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!autoplay)
        {
            moveWithMouse();
        }
        else
        {
            Autoplay();
        }
    }

    private void Autoplay()
    {
        Vector3 paddlePos = this.transform.position;
        Vector3 ballPos = Ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x - 0.5f, minX, maxX);
        this.transform.position = paddlePos;
    }

    private void moveWithMouse()
    {
        //We must find the cursors position and transform it to a valid screen position in x
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }
}
