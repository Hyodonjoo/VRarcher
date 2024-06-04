using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance { get; private set; }
	private List<IScore> scores;
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
	}

	public void AddScore(IScore score)
	{
		this.scores.Add(score);
		Debug.Log("Total Score: " + this.TotalScore);
	}
}
