using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text highScoreText; // Ссылка на текстовое поле для рекордного счета
    public static MenuManager Instance;
    
    private void Start()
    {
        // Загружаем рекордный счет из PlayerPrefs и обновляем его на сцене меню
        int highScore = PlayerPrefs.GetInt("HighScore", 0);       
        UpdateHighScoreUI(highScore);
    }

    public void UpdateHighScoreUI(int highScore)
    {
        highScoreText.text = "Рекорд: " + highScore;
    }

   

}
