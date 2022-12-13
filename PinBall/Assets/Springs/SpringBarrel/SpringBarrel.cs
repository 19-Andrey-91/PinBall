using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpringBarrel : MonoBehaviour
{
    [SerializeField]
    private float springPower;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;
        Rigidbody bodyBall = ball.GetComponent<Rigidbody>();
        Vector3 forceDirection = ball.transform.position - transform.position;
        bodyBall.AddForce(forceDirection * springPower, ForceMode.Impulse);
    }
}
