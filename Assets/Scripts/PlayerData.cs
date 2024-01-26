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

    public List<MissionBase> Missions = new();

    // Mission management
    public void AddMission()
    {
        int val = Random.Range(0, (int)MissionBase.MissionType.Max);
        MissionBase newMission = MissionBase.GetNewMissionFromType((MissionBase.MissionType)val);
        newMission.Created();
        Missions.Add(newMission);
    }
}
