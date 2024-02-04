using UnityEngine;

public class AmbientMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private void Start()
    {
        _music.Play();
    }
}
