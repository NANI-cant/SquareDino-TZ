using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyHealthbar : MonoBehaviour {
    [SerializeField] private EnemyHealth _health;

    private Slider _slider;
    private Transform _transform;
    private Transform _cameraTransform;

    private void Awake() {
        _slider = GetComponent<Slider>();
        _transform = transform;
        _cameraTransform = Camera.main.transform;
    }

    private void OnEnable() {
        _health.HitTaked += ChangeUI;
        _health.Died += OnDied;
    }

    private void OnDisable() {
        _health.HitTaked -= ChangeUI;
        _health.Died -= OnDied;
    }

    private void Start() {
        _slider.maxValue = _health.MaxHealth;
        _slider.minValue = 0;
        _slider.value = _health.CurrentHealth;
    }

    private void Update() {
        _transform.rotation = Quaternion.LookRotation(_transform.position - _cameraTransform.position);
    }

    private void OnDied(HitBox hitBox) => gameObject.SetActive(false);
    private void ChangeUI() => _slider.value = _health.CurrentHealth;
}
