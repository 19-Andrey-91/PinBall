using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBall : MonoBehaviour
{
    [SerializeField]
    GameObject ballPref;

    GameObject ball;

    Vector3 startBallVector = new Vector3(4, 2.87f, -5.4f);

    void Start()
    {
        ball = Instantiate(ballPref);
        MoveToStartingPosition();
    }

    public void MoveToStartingPosition() => ball.transform.position = startBallVector;
}
