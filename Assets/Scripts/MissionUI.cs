using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private RectTransform _missionPlace;
    [SerializeField] private MissionEntry _missionEntryPrefab;

    private void OnEnable()
    {
        Open();
    }
    public void Open()
    {
        gameObject.SetActive(true);

        MissionEntry entry = Instantiate(_missionEntryPrefab);
        entry.transform.SetParent(_missionPlace, false);

        for (int i = 0; i < PlayerData.Instance._missions.Count; i++)
        {

        }
    }

}
