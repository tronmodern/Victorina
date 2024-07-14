using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContButton : MonoBehaviour
{
    public GameObject panel;

    public void Continue()
    {
        HideEndGameWindow();
    }

    private void HideEndGameWindow()
    {
        panel.SetActive(false); // ������ ����

        // ���������� � QuestionManager ����� FindObjectOfType
        QuestionManager questionManager = FindObjectOfType<QuestionManager>();
        if (questionManager != null)
        {
            questionManager.ResetErrorCount();
        }
    }
}
