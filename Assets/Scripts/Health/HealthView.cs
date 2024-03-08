using UnityEngine;
using TMPro;
using Zenject;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private Health _playerHealth;

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
        _healthText.text = UIConstantStrings.BasisHealthText + _player.Health.Amount.ToString();
    }
}
