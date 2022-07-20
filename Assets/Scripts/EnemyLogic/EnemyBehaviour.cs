using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(EnemyAvatar))]
public class EnemyBehaviour : MonoBehaviour {
    [Header("Metrics")]
    [SerializeField][Min(0)] private int _maxHealth;

    public event Action Died;
    public event Action HitTaked;

    private bool _canTakeHit;
    private EnemyAvatar _avatar;
    private Collider _collider;
    private int _health;

    public Collider Collider => _collider;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _health;

    private void Awake() {
        _avatar = GetComponent<EnemyAvatar>();
        _collider = GetComponent<Collider>();

        _health = _maxHealth;
    }

    public void Attack(PlayerBehaviour character) {
        transform.forward = (character.transform.position - transform.position).normalized;
    }

    public void TakeHit() {
        if (!_canTakeHit) return;

        _health--;
        if (_health <= 0) {
            Die();
        }
        else {
            HitTaked?.Invoke();
        }
    }

    public void Disable() => _canTakeHit = false;
    public void Enable() => _canTakeHit = true;

    private void Die() {
        _collider.enabled = false;
        _avatar.Fall();
        Died?.Invoke();
    }
}