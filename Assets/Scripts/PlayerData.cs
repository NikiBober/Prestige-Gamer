using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Save data for the game in local binary file.
/// </summary>
public class PlayerData 
{
    private static PlayerData _instance;
    public static PlayerData Instance { get { return _instance; } }

    public List<MissionBase> _missions = new();

}
