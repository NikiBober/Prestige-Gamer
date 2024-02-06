using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnlocker : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameButtons;
    [SerializeField] private GameObject _lockedImage;

    private void Start()
    {
        _lockedImage.SetActive(true);
        var position = _gameButtons[1].transform.position;
        _lockedImage.transform.position = position;
    }
}
