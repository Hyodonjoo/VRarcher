using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private List<IScore> scores;

    public TextMeshProUGUI scoreText;

    public delegate void ScoreReached();
    public static event ScoreReached OnScoreReached;

    public int TotalScore
    {
        get
        {
            return this.scores.Select((x) => x.GetScore()).Sum();
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        this.scores = new List<IScore>();
    }

    public void Reset()
    {
        this.scores.Clear();
        UpdateScoreText();
    }

    public void AddScore(IScore score)
    {
        this.scores.Add(score);
        Debug.Log("Total Score: " + this.TotalScore);
        UpdateScoreText();
        if (this.TotalScore >= 10) // 점수가 50점 이상이면 이벤트 호출
        {
            OnScoreReached?.Invoke();
        }

    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = this.TotalScore.ToString() + "/50";
        }
    }
}
