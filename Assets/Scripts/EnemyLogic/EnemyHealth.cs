using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public event Action<HitBox> Died;
    public event Action HitTaked;

    private int _maxHealth;
    private int _health;
    private bool _canTakeHit = false;
    private HitBox[] _hitBoxes;
    private bool _alreadyTakeHitAtThisFrame = false;
    private Bounds _hitBoxesBounds;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _health;
    public Bounds HitBoxesBounds => _hitBoxesBounds;

    public EnemyHealth Initialize(int maxHealth) {
        _maxHealth = maxHealth;
        _health = _maxHealth;

        return this;
    }

    private void Awake() {
        _hitBoxes = GetComponentsInChildren<HitBox>();
        _hitBoxesBounds = new Bounds(transform.position, Vector3.zero);
        foreach (var hitBox in _hitBoxes) {
            _hitBoxesBounds.Encapsulate(hitBox.Collider.bounds);
        }
    }
    private void Update() => _alreadyTakeHitAtThisFrame = false;

    private void OnEnable() {
        foreach (var hitBox in _hitBoxes) {
            hitBox.HitTaked += OnHitTaked;
        }
    }

    private void OnDisable() {
        foreach (var hitBox in _hitBoxes) {
            hitBox.HitTaked -= OnHitTaked;
        }
    }

    public void Disable() => _canTakeHit = false;
    public void Enable() => _canTakeHit = true;

    private void OnHitTaked(HitBox hitbox) {
        if (!_canTakeHit || _alreadyTakeHitAtThisFrame) return;

        _alreadyTakeHitAtThisFrame = true;
        _health--;
        if (_health <= 0) {
            Died?.Invoke(hitbox);
        }
        else {
            HitTaked?.Invoke();
        }
    }
}
