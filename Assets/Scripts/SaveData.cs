using UnityEngine;

/// <summary>
/// Save data between sessions
/// </summary>

public class SaveData : Singleton<SaveData>
{
    private static readonly string _coinsScoreLabel = "CoinsScore";
    private static readonly string _premiumScoreLabel = "PremiumScore";

    private static int _coinsScore = 0;
    public static int CoinsScore { get => _coinsScore; }

    private static int _premiumScore = 0;
    public static int PremiumScore { get => _premiumScore; }

    private void OnEnable()
    {
        //EventManager.OnGameOver += GameOverHandler;
        EventManager.OnPremiumScoreUpdate += UpdatePremiumScoreHandler;

        _coinsScore = PlayerPrefs.GetInt(_coinsScoreLabel);
        _premiumScore = PlayerPrefs.GetInt(_premiumScoreLabel);
    }

    public static bool IsFirstLaunch()
    {
        return !PlayerPrefs.HasKey(_coinsScoreLabel);
    }

    private void UpdateCoinsScoreHandler(int amount)
    {
        _coinsScore += amount;
        PlayerPrefs.SetInt(_coinsScoreLabel, _coinsScore);
    }

    private void UpdatePremiumScoreHandler(int amount)
    {
        _premiumScore += amount;
        PlayerPrefs.SetInt(_premiumScoreLabel, _premiumScore);
    }


    //private void GameOverHandler()
    //{
    //    UpdateCoinsScore(ScoreCounter.Score);
    //}
}
