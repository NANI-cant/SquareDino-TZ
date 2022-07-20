using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyBehaviour : MonoBehaviour {
    public event Action Died;

    private bool _canTakeHit;

    public void Attack(PlayerBehaviour character) {
        transform.forward = (character.transform.position - transform.position).normalized;
    }

    private void OnDestroy() {
        Died?.Invoke();
    }

    public void TakeHit() {
        if (!_canTakeHit) return;

        Die();
    }

    private void Die() => Destroy(gameObject);
    public void Disable() => _canTakeHit = false;
    public void Enable() => _canTakeHit = true;
}