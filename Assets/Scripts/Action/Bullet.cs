using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour, IPoolable<Bullet> {
    private float _speed;
    private Transform _transform;

    public event Action<Bullet> Returned;

    private void Awake() {
        _transform = transform;
    }

    public void Initialize(float speed, Vector3 destination, float lifeTime) {
        _speed = speed;
        transform.forward = (destination - _transform.position).normalized;
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    private void Update() {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent<HitBox>(out HitBox hitBox)) {
            hitBox.TakeHit(_transform.forward);
        }
        ReturnToPool();
    }

    private void ReturnToPool() => Returned?.Invoke(this);
}