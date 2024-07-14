using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource; // ��������� ������ �� ��������� AudioSource

    private static MusicPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>(); // �������� ��������� AudioSource
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // ���� ������ ��������� ������, ������������� �
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}