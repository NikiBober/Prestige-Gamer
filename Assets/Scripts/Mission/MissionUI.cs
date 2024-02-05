using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private RectTransform _missionPlace;
    [SerializeField] private MissionEntry _missionEntryPrefab;

    private void OnEnable()
    {
        EventManager.OnClaimMission += ClaimMissionHandler;

        PlayerData.Instance.AddMission();
        Clear();
        Fill();
    }

    private void Clear()
    {
        foreach (RectTransform child in _missionPlace)
        {
            Destroy(child.gameObject);
        }
    }

    private void Fill()
    {
        for (int i = 0; i < PlayerData.Instance.Missions.Count; i++)
        {
            MissionEntry entry = Instantiate(_missionEntryPrefab);
            entry.transform.SetParent(_missionPlace, false);
            entry.FillWithMission(PlayerData.Instance.Missions[i], this);
        }
    }

    public void ClaimMissionHandler(MissionBase mission)
    {
        //PlayerData.Instance.ClaimMission(mission);

        //Debug.Log(mission.Reward);
        // Rebuild the UI with the new missions
        Clear();
        Fill();
    }

}
