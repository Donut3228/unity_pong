using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    // private static readonly Random random = new Random ();

    public GameObject ball;

    private int minBallSpeed = -7;
    private int maxBallSpeed = 7;

    private bool hitWall = false;
    private bool hitPaddle = false;
    private bool dead = false;
    private Vector2 dir;

    // private double RandomNumberBetween (double minValue, double maxValue) {
    //     var next = random.NextDouble ();

    //     return minValue + (next * (maxValue - minValue));
    // }

    private Vector2 GetRandomVector () {
        float x = 0.01f * (int) Random.Range (minBallSpeed, maxBallSpeed);
        float y = 0.01f * (int) Random.Range (minBallSpeed, maxBallSpeed);
        return new Vector2 (x, y);
    }

    void Start () {
        dir = GetRandomVector ();
        Invoke ("Move", 0.03f);
    }

    void Move () {
        if (hitWall == true) {
            Vector2 new_v = new Vector2 (dir.x, dir.y * -1.0f);
            dir = new_v;
            hitWall = false;
        } else if (hitPaddle == true) {
            Vector2 new_v = new Vector2 (dir.x * -1.0f, dir.y);
            dir = new_v;
            hitPaddle = false;
        } else if (dead == true) {
            GameObject.Destroy (ball);
        }
        transform.Translate (dir);
        Invoke ("Move", 0.03f);
    }

    // void Update () {
    //     if (hitWall == false) {
    //         hitWall = true;
    //     }
    // }

    void OnTriggerEnter2D (Collider2D other) {
        // Debug.Log(other.tag + " x = " + other.offset.x + " y = " + other.offset.y);
        if (other.CompareTag ("Paddle")) {
            hitPaddle = true;
        } else if (other.offset.x == 0) {
            hitWall = true;
        } else if (other.offset.y == 0) {
            dead = true;
        }
    }
}