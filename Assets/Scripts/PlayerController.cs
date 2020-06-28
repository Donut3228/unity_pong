using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Vector2 dir;

    private bool hitWall = false;

    void Start () {
        speed = 0.03f;
        Invoke ("Move", speed);
    }

    void Move () {
        if (hitWall == true) {
            dir = Vector2.zero;
            hitWall = false;
        }
        transform.Translate (dir * 0.0375f);
        Invoke ("Move", speed);
    }

    void Update () {
        if (Input.GetKey (KeyCode.DownArrow))
            dir = -Vector2.up;
        else if (Input.GetKey (KeyCode.UpArrow))
            dir = Vector2.up;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.name.StartsWith ("Background")) {
            hitWall = true;
        }
    }
}