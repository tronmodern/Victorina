using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAnimation : MonoBehaviour
{
    public Color glowColor;
    public float animationDuration = 1.0f;
    public float pressScaleFactor = 0.9f; 

    private Image buttonImage;
    private Color normalColor;
    private bool isPressed = false;

    private Vector3 originalScale;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        normalColor = buttonImage.color;

        originalScale = transform.localScale;
        
        StartCoroutine(ContinuousGlowAnimation());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverButton())
        {
            isPressed = true;
            buttonImage.color = glowColor;
            transform.localScale = originalScale * pressScaleFactor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            buttonImage.color = normalColor;
            transform.localScale = originalScale;
        }
    }

    private bool IsMouseOverButton()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return GetComponent<RectTransform>().rect.Contains(mousePosition);
    }

    private IEnumerator ContinuousGlowAnimation()
    {
        while (true)
        {
            if (!isPressed)
            {
                float elapsedTime = 0f;
                Color startingColor = buttonImage.color;

                while (elapsedTime < animationDuration)
                {
                    buttonImage.color = Color.Lerp(startingColor, glowColor, elapsedTime / animationDuration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                elapsedTime = 0f;
                startingColor = buttonImage.color;

                while (elapsedTime < animationDuration)
                {
                    buttonImage.color = Color.Lerp(startingColor, normalColor, elapsedTime / animationDuration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }

            yield return null;
        }
    }
}