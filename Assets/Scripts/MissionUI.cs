using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private RectTransform _missionPlace;
    [SerializeField] private MissionEntry _missionEntryPrefab;

    private void OnEnable()
    {
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

    public void Claim(MissionBase mission)
    {
/*        PlayerData.instance.ClaimMission(m);

        // Rebuild the UI with the new missions
        StartCoroutine(Open());
*/    }


}
