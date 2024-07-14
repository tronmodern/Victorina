using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public int answerIndex;

    private QuestionManager questionManager;

    private void Start()
    {
        questionManager = FindObjectOfType<QuestionManager>();
    }

    public void OnAnswerButtonClicked()
    {      
        questionManager.OnAnswerSelected(answerIndex);        
    }
}
