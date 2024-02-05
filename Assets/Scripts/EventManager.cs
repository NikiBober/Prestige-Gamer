
using UnityEngine;
/// <summary>
/// Crosspoint for events
/// </summary>
public class EventManager
{
    //public delegate void GameAction();
    //public static event GameAction OnGameOver;
    //public static event GameAction OnTogglePause;
    //public static event GameAction OnUpdateAbility;

    public delegate void ScoreUpdateAction(int score);
    public static event ScoreUpdateAction OnPremiumScoreUpdate;
    public static event ScoreUpdateAction OnCoinsScoreUpdate;

    public delegate void ClaimMissionAction(MissionBase mission);
    public static event ClaimMissionAction OnClaimMission;

    //public static void GameOver()
    //{
    //    OnGameOver();
    //}

    //public static void TogglePause()
    //{
    //    OnTogglePause();
    //}

    //public static void UpdateAbility()
    //{
    //    OnUpdateAbility();
    //}

    public static void ClaimMission(MissionBase mission)
    {
        OnClaimMission(mission);
        OnPremiumScoreUpdate(mission.Reward);
    }


    public static void PremiumScoreUpdate(int score)
    {
        OnPremiumScoreUpdate(score);
    }

    public static void CoinsScoreUpdate(int score)
    {
        OnCoinsScoreUpdate(score);
    }
}
