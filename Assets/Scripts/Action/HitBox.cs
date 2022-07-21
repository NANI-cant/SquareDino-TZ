using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitBox : MonoBehaviour {
    public event Action<HitBox> HitTaked;

    private Rigidbody _rigidbody;
    private Vector3 _lastHitDirection;
    private Collider _collider;

    public Collider Collider => _collider;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void TakeHit(Vector3 direction) {
        _lastHitDirection = direction;
        HitTaked?.Invoke(this);
    }

    public void ImpactForce(float force) {
        if (_rigidbody == null) return;

        _rigidbody.AddForce(_lastHitDirection * force, ForceMode.Impulse);
    }
}