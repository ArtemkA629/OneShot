using UnityEngine;
using TMPro;
using Zenject;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private Health _playerHealth;

    private const string _basisHealthText = "Health: ";

    [Inject] private readonly Player _player;

    private void Start()
    {
        _playerHealth = _player.Health;
        _playerHealth.Changed += OnHealthChanged;
        OnHealthChanged();
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        _healthText.text = _basisHealthText + _player.Health.Amount.ToString();
    }
}
