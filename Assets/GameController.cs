using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	public event Action<int> OnScoreChange;
	private int score = 0;

	void Awake()
	{
		if (Instance != null)
		{
			return;
		}
		Instance = this;
	}

	public void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
		OnScoreChange?.Invoke(score);
	}
}
