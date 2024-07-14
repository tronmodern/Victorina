using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.Instance.currentLevelIndex = 0;

    }

    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
        GameManager.Instance.currentLevelIndex = 0;
    }
}
