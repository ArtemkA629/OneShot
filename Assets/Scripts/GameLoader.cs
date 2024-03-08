using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private LevelButton[] _buttons;

    public static event Action<LevelDifficulty> LevelChosen;

    private void OnEnable()
    {
        foreach (var button in _buttons)
            button.Clicked += OnLevelButtonClicked;
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            button.Clicked += OnLevelButtonClicked;
    }

    private void OnLevelButtonClicked(LevelDifficulty levelDifficulty)
    {
        SceneManager.LoadScene(SceneNames.Game);
        LevelChosen?.Invoke(levelDifficulty);
    }
}
