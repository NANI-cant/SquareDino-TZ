using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyBehaviour : MonoBehaviour {
    public event Action Died;

    public void Attack(PlayerBehaviour character) {
        transform.forward = (character.transform.position - transform.position).normalized;
    }

    private void OnDestroy() {
        Died?.Invoke();
    }

    public void TakeHit() {
        Die();
    }

    private void Die() => Destroy(gameObject);
}