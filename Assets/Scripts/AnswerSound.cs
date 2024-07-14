using UnityEngine;
using UnityEngine.UI;

public class AnswerSound : MonoBehaviour
{
    private Button button;
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;
    private AudioSource audioSource; // Подключите ваш AudioSource в инспекторе

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
    }

    public void PlayCorrectAnswerSound()
    {
        audioSource.clip = correctAnswerSound;
        audioSource.Play();
    }

    public void PlayWrongAnswerSound()
    {
        audioSource.clip = wrongAnswerSound;
        audioSource.Play();
    }
}
