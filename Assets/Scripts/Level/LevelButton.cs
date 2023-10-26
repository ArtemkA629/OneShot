using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelDifficulty _levelDifficulty;

    public void Load()
    {
        SceneManager.LoadScene(1);
        LevelDataHolder.LevelDifficulty = _levelDifficulty;
    }
}
