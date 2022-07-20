using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(EnemyAvatar))]
public class EnemyBehaviour : MonoBehaviour {
    public event Action Died;

    private bool _canTakeHit;
    private EnemyAvatar _avatar;
    private Collider _collider;

    public Collider Collider => _collider;

    private void Awake() {
        _avatar = GetComponent<EnemyAvatar>();
        _collider = GetComponent<Collider>();
    }

    public void Attack(PlayerBehaviour character) {
        transform.forward = (character.transform.position - transform.position).normalized;
    }

    public void TakeHit() {
        if (!_canTakeHit) return;

        Die();
    }

    public void Disable() => _canTakeHit = false;
    public void Enable() => _canTakeHit = true;

    private void Die() {
        _collider.enabled = false;
        _avatar.Fall();
        Died?.Invoke();
    }
}