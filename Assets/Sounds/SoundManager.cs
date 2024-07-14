using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Sprite soundOnSprite; // ������ ��� ����������� �����
    public Sprite soundOffSprite; // ������ ��� ������������ �����
    public static bool isSoundOn = true; // ����������� ���������� ��� ��������� �����
    public Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        UpdateButtonImage();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        AudioListener.volume = isSoundOn ? 1 : 0;
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        }
    }
}
