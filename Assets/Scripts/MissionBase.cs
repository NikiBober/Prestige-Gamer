using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class used to define a mission the player needs to complete to gain some premium currency.
/// Subclassed for every mission.
/// </summary>

public abstract class MissionBase
{
    public enum MissionType
    {
        Time,
        Max
    }

    public float Progress;
    public int Max;
    public int Reward;

    public bool IsComplete { get { return (Progress / Max) >= 1.0f; } }

    public abstract void Created();
    public abstract string GetMissionDesc();
    public abstract void Update(MissionTracker tracker);


    public static MissionBase GetNewMissionFromType(MissionType type)
    {
        switch (type)
        {
            case MissionType.Time:
                return new TimeMission();
        }

        return null;
    }

    public class TimeMission : MissionBase
    {
        public override void Created()
        {
            int[] maxValues = { 1, 2, 3, 4 };
            int choosenVal = Random.Range(0, maxValues.Length);

            Reward = choosenVal + 1;
            Max = maxValues[choosenVal];
            Progress = 0;
        }

        public override string GetMissionDesc()
        {
            return $"Play any game for {Max} seconds";
        }

        public override void Update(MissionTracker tracker)
        {
            Progress = tracker.Time;
        }
    }
}
