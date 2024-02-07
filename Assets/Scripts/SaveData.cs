using UnityEngine;

/// <summary>
/// Save data between sessions
/// </summary>

public class SaveData : Singleton<SaveData>
{
    private static readonly string _coinsScoreLabel = "CoinsScore";
    private static readonly string _premiumScoreLabel = "PremiumScore";
    private static readonly string _unlockedGamesCountLabel = "UnlockedGamesCount";

    private static int _coinsScore = 0;
    public static int CoinsScore { get => _coinsScore; }

    private static int _premiumScore = 0;
    public static int PremiumScore { get => _premiumScore; }

    private static int _unlockedGamesCount = 1;
    public static int UnlockedGamesCount { get => _unlockedGamesCount; }

    private void OnEnable()
    {
        //EventManager.OnGameOver += GameOverHandler;
        EventManager.OnPremiumScoreUpdate += UpdatePremiumScoreHandler;
        //PlayerPrefs.SetInt(_unlockedGamesCountLabel, 1);
        //PlayerPrefs.SetInt(_premiumScoreLabel, 1);

        _coinsScore = PlayerPrefs.GetInt(_coinsScoreLabel);
        _premiumScore = PlayerPrefs.GetInt(_premiumScoreLabel);
        _unlockedGamesCount = PlayerPrefs.GetInt(_unlockedGamesCountLabel, _unlockedGamesCount);
    }

    //public static bool IsFirstLaunch()
    //{
    //    return !PlayerPrefs.HasKey(_coinsScoreLabel);
    //}

    public static void UnlockNextGame()
    {
        _unlockedGamesCount++;
        PlayerPrefs.SetInt(_unlockedGamesCountLabel, _unlockedGamesCount);
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
