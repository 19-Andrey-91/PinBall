using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBall : MonoBehaviour
{
    [SerializeField]
    GameObject ballPref;

    GameObject ball;
    Rigidbody ballRb;

    Vector3 startBallVector = new Vector3(4, 2.87f, -5.4f);

    void Start()
    {
        ball = Instantiate(ballPref);
        ballRb = ball.GetComponent<Rigidbody>();
        MoveToStartingPosition();
    }

    public void MoveToStartingPosition()
    {
        ballRb.velocity = Vector3.zero;
        ball.transform.position = startBallVector;
    }
}

public enum PointSprings
{
    Barrel = 100,
    WallBarrel = 50
}
