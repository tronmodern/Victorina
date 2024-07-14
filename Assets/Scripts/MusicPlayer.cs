using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource; // Добавляем ссылку на компонент AudioSource

    private static MusicPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Если музыка закончила играть, перезапускаем её
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}