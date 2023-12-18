using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private MonoBehaviour[] _inputScripts;

    public void Stop()
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
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
}
