using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;
    public WrongButtonAnimation[] wrongButtonAnimations;
    public CorrectButtonAnimation[] correctButtonAnimation;
    public AnswerSound[] AnswerSounds;

    public Image questionImage;
    public Text[] answerOptionTexts;
    public Image correctAnswerImage;
    public Text scoreText;
    public Text levelText;
    public Text errorText;

    public LevelData currentLevelData;
    private int currentLevelIndex = 0;
    private bool canInteract = true;
    public int score = 0;
    public int levelData = 0;

    public int errorCount = 0;
    public int maxErrors = 3;
    public GameObject panel;

    private void Start()
    {
        currentLevelData = GameManager.Instance.GetCurrentLevelData();
        PlayerPrefs.DeleteKey("FinalScore");
        UpdateQuestionUI();
        UpdateScoreUI();
        UpdateLevelUI();
        UpdateErrorUI();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void UpdateQuestionUI()
    {
        questionImage.sprite = currentLevelData.questionImage;

        for (int i = 0; i < answerOptionTexts.Length; i++)
        {
            answerOptionTexts[i].text = currentLevelData.answerOptions[i];
        }
    }

    public void OnAnswerSelected(int selectedAnswerIndex)
    {

        if (!canInteract)
        {
            return;
        }

        int correctAnswerIndex = currentLevelData.correctAnswerIndex;

        if (selectedAnswerIndex == correctAnswerIndex)
        {
            //PlayerPrefs.DeleteAll();
            AnswerSounds[selectedAnswerIndex].PlayCorrectAnswerSound();
            correctButtonAnimation[correctAnswerIndex].PlayCorrectAnswerAnimation();
            correctAnswerImage.sprite = currentLevelData.correctAnswerImage;
            canInteract = false;
            score += 15;
            UpdateScoreUI();

            // Проверяем, обновляется ли рекордный счет
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }

            StartCoroutine(DelayBeforeNextLevel());
        }
        else
        {
            errorCount++;
            UpdateErrorUI();
            if (errorCount >= maxErrors)
            {
                ShowEndGameWindow();   
            }
            AnswerSounds[selectedAnswerIndex].PlayWrongAnswerSound();
            wrongButtonAnimations[selectedAnswerIndex].StartBlinkAnimation();
            score = Mathf.Max(score - 20, 0);
            UpdateScoreUI();

            Debug.Log("Неправильный ответ!");
        }
    }
    private void ShowEndGameWindow()
    {
        panel.SetActive(true); // Показать окно
    }

    public void ResetErrorCount()
    {
        errorCount = 0;  
        UpdateErrorUI();
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Счет: " + score;
    }

    private void UpdateErrorUI()
    {
        errorText.text = errorCount + "/3";
    }
    private void UpdateLevelUI()
    {

        levelData++;
        levelText.text = levelData.ToString() + "/20";
    }

   


    private IEnumerator DelayBeforeNextLevel()
    {
        yield return new WaitForSeconds(1.0f);

        if (levelData < 20)
        {
            GameManager.Instance.LoadNextLevel();
            currentLevelData = GameManager.Instance.GetCurrentLevelData();
            UpdateQuestionUI();
            UpdateLevelUI();
            canInteract = true;
        }
        else
        {
            PlayerPrefs.SetInt("FinalScore", score);
            SceneManager.LoadScene(2);
        }
    }
}