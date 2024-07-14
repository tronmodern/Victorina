using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data", order = 1)]
public class LevelData : ScriptableObject
{
    public Sprite questionImage;
    public string[] answerOptions;
    public int correctAnswerIndex;
    public Sprite correctAnswerImage;
}
