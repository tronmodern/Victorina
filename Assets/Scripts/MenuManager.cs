using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text highScoreText; // ������ �� ��������� ���� ��� ���������� �����
    public static MenuManager Instance;
    
    private void Start()
    {
        // ��������� ��������� ���� �� PlayerPrefs � ��������� ��� �� ����� ����
        int highScore = PlayerPrefs.GetInt("HighScore", 0);       
        UpdateHighScoreUI(highScore);
    }

    public void UpdateHighScoreUI(int highScore)
    {
        highScoreText.text = "������: " + highScore;
    }

   

}
