using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D ball) {
        if (ball.name == "Ball") {
            if (this.name == "Left") {
                ball.GetComponent<Ball>().resetBall("Right");
            } else if (this.name == "Right") {
                ball.GetComponent<Ball>().resetBall("Left");
            }
        }
    }
}
