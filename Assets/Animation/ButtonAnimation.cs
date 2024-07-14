using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongButtonAnimation : MonoBehaviour
{
    public float blinkDuration = 1.0f; // Длительность мигания
    public int blinkCount = 3; // Количество миганий
    public Color blinkColor = Color.red; // Цвет мигания
    private Color originalColor;
    private bool isAnimating = false;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.colors.normalColor;
    }

    public void StartBlinkAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(BlinkAnimation());
        }
    }

    private IEnumerator BlinkAnimation()
    {
        for (int i = 0; i < blinkCount * 2; i++)
        {
            button.colors = GetButtonColor(i % 2 == 0 ? blinkColor : originalColor);
            yield return new WaitForSeconds(blinkDuration / blinkCount);
        }
        isAnimating = false;
    }

    private ColorBlock GetButtonColor(Color color)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = color;
        colorBlock.highlightedColor = color;
        colorBlock.pressedColor = color;
        colorBlock.selectedColor = color;
        return colorBlock;
    }
}
