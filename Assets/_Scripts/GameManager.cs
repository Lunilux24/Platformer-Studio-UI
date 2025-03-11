using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (coinCounter == null)
        {
            coinCounter = Object.FindFirstObjectByType<CoinCounterUI>();
            if (coinCounter == null)
            {
                Debug.LogError("CoinCounterUI not found in the scene!");
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
    }
}
