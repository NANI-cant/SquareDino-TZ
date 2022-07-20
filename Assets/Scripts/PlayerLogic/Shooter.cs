using System;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [Header("Dev")]
    [SerializeField] private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private Vector3 _shootingOffset;

    private Transform _transform;
    private bool _isAllow;
    private float _bulletSpeed;
    private float _bulletLifeTime;

    private void Awake() {

    }

    public Shooter Initialize(float bulletSpeed, float bulletLifeTime) {
        _bulletLifeTime = bulletLifeTime;
        _bulletSpeed = bulletSpeed;

        _transform = transform;
        _bulletPool.Initialize();
        Forbid();

        return this;
    }

    public void Allow() => _isAllow = true;
    public void Forbid() => _isAllow = false;

    public void Shot(Vector3 target) {
        if (!_isAllow) return;

        var bullet = _bulletPool.Take(_transform.TransformPoint(_shootingOffset), Quaternion.identity);
        bullet.Initialize(_bulletSpeed, target, _bulletLifeTime);
    }

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private Color _gizmoColor = Color.blue;
    [SerializeField] private float _gizmoRadius = 0.2f;

    private void OnDrawGizmosSelected() {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.TransformPoint(_shootingOffset), _gizmoRadius);
    }
#endif
}
