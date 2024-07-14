using UnityEngine;
using UnityEngine.UI;

public class AnswerSound : MonoBehaviour
{
    private Button button;
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;
    private AudioSource audioSource; // ���������� ��� AudioSource � ����������

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // �������� ��������� AudioSource
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
