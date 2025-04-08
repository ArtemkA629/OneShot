using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private MonoBehaviour[] _inputScripts;

    [Inject] private readonly Player _player;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        foreach (var script in _inputScripts)
            script.enabled = false;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ExitGameOverPanel(int sceneIndex)
    {
        YGAdsProvider.TryShowFullScreenAdWithChance();
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
}
