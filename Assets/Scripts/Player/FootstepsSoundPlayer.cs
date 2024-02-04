using UnityEngine;

public class FootstepsSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _footstepsSound;
    [SerializeField] private float _stepDistance;

    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = transform.position;
    }

    public void Play()
    {
        float distanceMoved = Vector3.Distance(transform.position, _lastPosition);
        if (distanceMoved >= _stepDistance)
        {
            _footstepsSound.Play();
            _lastPosition = transform.position;
        }
    }
}
