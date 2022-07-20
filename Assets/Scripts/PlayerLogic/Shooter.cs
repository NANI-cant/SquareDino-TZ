using System;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [Header("Metrics")]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifeTime;

    [Header("Dev")]
    [SerializeField] private ObjectPool<Bullet> _bulletPool;
    [SerializeField] private Vector3 _shootingOffset;

    private Transform _transform;
    private bool _isAllow;

    private void Awake() {
        _transform = transform;
        _bulletPool.Initialize(null);
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
