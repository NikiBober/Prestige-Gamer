using UnityEngine;
using UnityEngine.UI;

public class MissionEntry : MonoBehaviour
{
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Text _rewardText;
    [SerializeField] private Button _claimButton;
    [SerializeField] private Text _progressText;
	[SerializeField] private Image _background;

	[SerializeField] private Color _completedColor;
    
    public void FillWithMission(MissionBase mission, MissionUI owner)
    {
        _descriptionText.text = mission.GetMissionDesc();
        _rewardText.text = mission.Reward.ToString();
        _progressText.text = $"{(int)mission.Progress} / {mission.Max}";

        if (mission.IsComplete)
        {
            _claimButton.gameObject.SetActive(true);

            _background.color = _completedColor;

            //_claimButton.onClick.AddListener(() => owner.Claim(mission));
            _claimButton.onClick.AddListener(() => EventManager.ClaimMission(mission));
        }
    }
}
