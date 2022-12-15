using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    public delegate void GameOverHandler();
    public event GameOverHandler gameOver;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameOver?.Invoke();
        }
    }
}
