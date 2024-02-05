using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TextMeshProUGUI _progressText;

    public void LoadScene(string sceneToLoad)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneRoutine(sceneToLoad));
    }

    private IEnumerator LoadSceneRoutine(string sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f) * 100;

            _progressBar.value = progress;
            _progressText.text = $"Loading... {Mathf.Round(progress)}%";

            yield return null;

        }

        //Time.timeScale = 1.0f;
        _loadingScreen.SetActive(false);
    }
}
