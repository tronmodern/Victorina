using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CorrectButtonAnimation : MonoBehaviour
{
    public float animationDuration = 1.0f;
    public Color correctColor = Color.green;
    private Color originalColor;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.colors.normalColor;
    }

    public void PlayCorrectAnswerAnimation()
    {
        StartCoroutine(CorrectAnswerAnimation());
    }

    private IEnumerator CorrectAnswerAnimation()
    {
        float elapsedTime = 0f;
        Color originalButtonColor = button.colors.normalColor;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            Color lerpedColor = Color.Lerp(originalButtonColor, correctColor, t);
            SetButtonColor(lerpedColor);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Возвращаем цвет кнопки к исходному
        SetButtonColor(originalColor);
    }

    private void SetButtonColor(Color color)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = color;
        colorBlock.highlightedColor = color;
        colorBlock.pressedColor = color;
        colorBlock.selectedColor = color;
        button.colors = colorBlock;
    }
}