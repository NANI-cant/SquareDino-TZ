using UnityEngine;

[RequireComponent(typeof(EnemyAvatar))]
[RequireComponent(typeof(EnemyHealth))]
public class EnemyBehaviour : MonoBehaviour {
    [Header("Metrics")]
    [SerializeField][Min(0)] private int _maxHealth;
    [SerializeField][Min(0)] private float _lastHitForce = 100f;

    private EnemyAvatar _avatar;
    private EnemyHealth _health;

    public Bounds Bounds => _health.HitBoxesBounds;
    public EnemyHealth Health => _health;

    private void Awake() {
        _avatar = GetComponent<EnemyAvatar>();
        _health = GetComponent<EnemyHealth>().Initialize(_maxHealth);
    }

    private void OnEnable() => _health.Died += OnDied;
    private void OnDisable() => _health.Died -= OnDied;

    public void Attack(PlayerBehaviour character) {
        transform.forward = (character.transform.position - transform.position).normalized;
    }

    private void OnDied(HitBox lastHitBox) {
        _avatar.Fall();
        lastHitBox.ImpactForce(_lastHitForce);
    }
}