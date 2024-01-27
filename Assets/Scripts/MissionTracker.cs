using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MissionTracker : MonoBehaviour
{
    private int _time;
    public int Time { get => _time; }

    private void Start()
    {
        _time = 0;
        StartCoroutine(CountSecondsRoutine());
    }

    private IEnumerator CountSecondsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _time++;
            PlayerData.Instance.UpdateMissions(this);
        }
    }
}
