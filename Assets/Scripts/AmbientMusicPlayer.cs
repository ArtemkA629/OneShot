using UnityEngine;

public class AmbientMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private void Start()
    {
        _music.Play();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            _music.Pause();
        else
            _music.UnPause();
    }
}
