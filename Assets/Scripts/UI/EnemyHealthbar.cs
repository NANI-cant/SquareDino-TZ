using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyHealthbar : MonoBehaviour {
    [SerializeField] private EnemyBehaviour _enemy;

    private Slider _slider;
    private Transform _transform;
    private Transform _cameraTransform;

    private void Awake() {
        _slider = GetComponent<Slider>();
        _transform = transform;
        _cameraTransform = Camera.main.transform;
    }

    private void OnEnable() {
        _enemy.HitTaked += ChangeUI;
        _enemy.Died += OnDied;
    }

    private void OnDisable() {
        _enemy.HitTaked -= ChangeUI;
        _enemy.Died -= OnDied;
    }

    private void Start() {
        _slider.maxValue = _enemy.MaxHealth;
        _slider.minValue = 0;
        _slider.value = _enemy.CurrentHealth;
    }

    private void Update() {
        _transform.rotation = Quaternion.LookRotation(_transform.position - _cameraTransform.position);
    }

    private void OnDied() => gameObject.SetActive(false);
    private void ChangeUI() => _slider.value = _enemy.CurrentHealth;
}
