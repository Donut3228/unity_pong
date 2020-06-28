using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private bool hitWall = false;
    private Vector2 dir;
    void Start () {
        dir = new Vector2 (0.01f, -0.01f);
        Invoke("Move", 0.03f);
    }

    void Move () {
        if (hitWall == true) {
            Vector2 new_v = new Vector2(dir.x, dir.y * -1.0f);
            dir = new_v;
            hitWall = false;
        }
        transform.Translate (dir);
        Invoke ("Move", 0.03f);
    }

    // void Update () {
    //     if (hitWall == false) {
    //         hitWall = true;
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        hitWall = true;
    }
}