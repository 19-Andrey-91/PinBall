using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    [SerializeField]
    private KeyCode _key;

    [SerializeField]
    public Vector3 vectorForce;

    [SerializeField]
    [Range(0, 30)]
    public int maxTimeSec;

    private Rigidbody _ball;
    public TimeSpan timeSpan;

    private Stopwatch _stopwatch = new();

    private void Update()
    {
        if (_ball != null)
        {
            if (Input.GetKeyDown(_key))
            {
                _stopwatch.Start();
            }
            if (Input.GetKeyUp(_key))
            {
                _stopwatch.Stop();
                timeSpan = _stopwatch.Elapsed;
                _stopwatch.Reset();
                Hit();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;
        _ball = ball.GetComponent<Rigidbody>();
    }

    private void Hit()
    {
        _ball.AddForce(vectorForce.x, vectorForce.y * CoefficientPower(), vectorForce.z, ForceMode.Impulse);
        _ball = null;
    }

    private float CoefficientPower()
    {
        float coefficient;
        float timePressButton = timeSpan.Seconds + timeSpan.Milliseconds / 1000f;
        

        if (timePressButton > maxTimeSec)
        {
            coefficient = 1f;
        }
        else
        {
            coefficient = timePressButton  / maxTimeSec;
        }
        return coefficient;
    }

}
