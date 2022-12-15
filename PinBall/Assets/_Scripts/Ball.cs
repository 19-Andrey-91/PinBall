using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreGT;

    private void OnCollisionEnter(Collision collision)
    {
        IPointGeter pointGeter = collision.gameObject.GetComponent<IPointGeter>();
        if (pointGeter != null)
        {
            int score;
            int.TryParse(scoreGT.text, out score);
            score += (int)pointGeter.Spring;
            scoreGT.text = score.ToString();
        }
    }
}
