using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerRotator))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(PlayerAvatar))]
public class PlayerBehaviour : MonoBehaviour {
    [Header("Metrics")]

    [Header("Movement")]
    [SerializeField][Min(0)] private float _movementSpeed = 5f;
    [SerializeField][Min(0)] private float _timeForRotation = 0.2f;

    [Header("Shooting")]
    [SerializeField][Min(0)] private float _bulletSpeed;
    [SerializeField][Min(0)] private float _bulletLifeTime;

    private Shooter _shooter;
    private PlayerStateMachine _stateMachine;

    private void Awake() {
        _shooter = GetComponent<Shooter>().Initialize(_bulletSpeed, _bulletLifeTime);

        PlayerMover mover = GetComponent<PlayerMover>().Initialize(_movementSpeed);
        PlayerRotator rotator = GetComponent<PlayerRotator>().Initialize(_timeForRotation);
        PlayerAvatar avatar = GetComponent<PlayerAvatar>();

        if (Bootstrapper.TryGetInstance<BattlesHandler>(out BattlesHandler battleHandler) == false) {
            Debug.LogException(new System.Exception($"{this}: {nameof(battleHandler)} is null"));
        }
        if (Bootstrapper.TryGetInstance<GameLifeCycle>(out GameLifeCycle gameLifeCycle) == false) {
            Debug.LogException(new System.Exception($"{this}: {nameof(gameLifeCycle)} is null"));
        }

        _stateMachine = new PlayerStateMachine(_shooter, battleHandler, mover, rotator, this, gameLifeCycle, avatar);
    }

    private void Start() => _stateMachine.TranslateTo<PlayerPrepearingState>();
    public void Shoot(Vector3 target) => _shooter.Shot(target);
}