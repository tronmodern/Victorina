using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {

        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        scoreText.text = finalScore.ToString();
    }

}
