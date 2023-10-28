using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelDifficulty _levelDifficulty;

    public LevelDifficulty LevelDifficulty => _levelDifficulty;

    public void Load()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }
}
