using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            foreach (var audioSource in _audioSources)
                audioSource.Pause();
        else
            foreach (var audioSource in _audioSources)
                audioSource.UnPause();
    }
}
