using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    private bool hasStarted = false;
    private paddle Paddle;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start()
    {
        Paddle = GameObject.FindObjectOfType<paddle>();
        paddleToBallVector = this.transform.position - Paddle.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = Paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
