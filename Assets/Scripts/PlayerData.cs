using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Save data for the game.
/// </summary>
public class PlayerData : Singleton<PlayerData>
{
    public List<MissionBase> Missions = new();

    private void OnEnable()
    {
        EventManager.OnClaimMission += ClaimMissionHandler;
    }

    // Mission management
    public void AddMission()
    {
        int index = Random.Range(0, (int)MissionBase.MissionType.Max);
        MissionBase newMission = MissionBase.GetNewMissionFromType((MissionBase.MissionType)index);
        newMission.Created();
        Missions.Add(newMission);
    }

    public void UpdateMissions(MissionTracker tracker)
    {
        for (int i = 0; i < Missions.Count; i++)
        {
            Missions[i].Update(tracker);
        }
    }

    public void ClaimMissionHandler(MissionBase mission)
    {
        Missions.Remove(mission);

        AddMission();

        //Save();
    }

}
