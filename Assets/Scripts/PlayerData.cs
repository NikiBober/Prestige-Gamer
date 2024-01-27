using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// Save data for the game in local binary file.
/// </summary>
public class PlayerData 
{
    private static PlayerData _instance = new();
    public static PlayerData Instance { get { return _instance; } }

    private int _premium;

    public List<MissionBase> Missions = new();

    // Mission management
    public void AddMission()
    {
        int index = Random.Range(0, (int)MissionBase.MissionType.Max);
        MissionBase newMission = MissionBase.GetNewMissionFromType((MissionBase.MissionType)index);
        newMission.Created();
        Missions.Add(newMission);
    }

    public void ClaimMission(MissionBase mission)
    {
        _premium += mission.Reward;

        Missions.Remove(mission);

        AddMission();

        //Save();
    }

    public void UpdateMissions(MissionTracker tracker)
    {
        for (int i = 0; i < Missions.Count; i++)
        {
            Missions[i].Update(tracker);
        }
    }


}
