using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelDifficulty _levelDifficulty;

    public static event Action<LevelDifficulty> LevelChosen;

    public void Load()
    {
        SceneManager.LoadScene(1);
        LevelChosen?.Invoke(_levelDifficulty);
    }
}
