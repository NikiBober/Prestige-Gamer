using TMPro;
using UnityEngine;

public class GameUnlocker : Singleton<GameUnlocker>
{
    [SerializeField] private GameObject[] _gameButtons;
    [SerializeField] private GameObject _lockedImage;
    [SerializeField] private int[] _unlockValues;
    [SerializeField] private TextMeshProUGUI _unlockValueText;

    private void OnEnable()
    {
        EventManager.OnPremiumScoreUpdate += TryUnlock;
    }

    private void Start()
    {
        for (int i = 0; i < SaveData.UnlockedGamesCount; i++)
        {
            _gameButtons[i].SetActive(true);
        }
        Refresh();
    }

    private void Refresh()
    {
        if (SaveData.UnlockedGamesCount < _gameButtons.Length)
        {
            _gameButtons[SaveData.UnlockedGamesCount].SetActive(true);
            _lockedImage.transform.position = _gameButtons[SaveData.UnlockedGamesCount].transform.position;
            _unlockValueText.text = _unlockValues[SaveData.UnlockedGamesCount].ToString();
        }
        else
        {
            _lockedImage.SetActive(false);
            EventManager.OnPremiumScoreUpdate -= TryUnlock;
        }
    }

    private void TryUnlock(int score)
    {
        if (SaveData.PremiumScore > _unlockValues[SaveData.UnlockedGamesCount])
        {
            SaveData.UnlockNextGame();
            Refresh();
        }
    }
}
