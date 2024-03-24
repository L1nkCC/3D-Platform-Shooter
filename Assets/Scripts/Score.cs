using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Score",order = 1)]
public class Score : ScriptableObject
{
    public int round = 0;
    public int score = 0;
    public event System.Action Update;
    public void Reset()
    {
        score = 0;
        round = 0;
    }

    public void IncrementScore()
    {
        score++;
        Update?.Invoke();
    }
    public void IncrementRound()
    {
        round++;
        Update?.Invoke();
    }

    public string StringScore()
    {
        return "Round: " + (round+1) + "\nScore: " + score;
    }
}
