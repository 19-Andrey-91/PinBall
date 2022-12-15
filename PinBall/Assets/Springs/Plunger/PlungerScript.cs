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
    private Vector3 _vectorForce;

    [SerializeField]
    [Range(0, 30)]
    private int _maxTimeSec;

    private Rigidbody _ball;
    private TimeSpan _timeSpan;
    private bool _pressedKey;
    private Stopwatch _stopwatch = new();

    public Vector3 VectorForce { get => _vectorForce; }
    public int MaxTimeSec { get => _maxTimeSec; }
    public TimeSpan TimeSpan { get => _timeSpan; }
    public bool PressedKey { get => _pressedKey; }


    private void Update()
    {
        if (_ball != null)
        {
            if (Input.GetKeyDown(_key))
            {
                _stopwatch.Start();
                _pressedKey = true;
            }
            if (Input.GetKeyUp(_key))
            {
                _stopwatch.Stop();
                _timeSpan = _stopwatch.Elapsed;
                _pressedKey = false;
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
        _ball.AddForce(_vectorForce.x, _vectorForce.y * CoefficientPower(), _vectorForce.z, ForceMode.Impulse);
        _ball = null;
    }

    private float CoefficientPower()
    {
        float coefficient;
        float timePressButton = _timeSpan.Seconds + _timeSpan.Milliseconds / 1000f;


        if (timePressButton > _maxTimeSec)
        {
            coefficient = 1f;
        }
        else
        {
            coefficient = timePressButton / _maxTimeSec;
        }
        return coefficient;
    }
}
