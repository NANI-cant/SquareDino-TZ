using UnityEngine;

[RequireComponent(typeof(BattlesHandler))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerRotator))]
[RequireComponent(typeof(Shooter))]
public class PlayerBehaviour : MonoBehaviour {
    private BattlesHandler _battleHandler;
    private PlayerMover _mover;
    private PlayerRotator _rotator;
    private Shooter _shooter;
    private PlayerStateMachine _stateMachine;

    private void Awake() {
        _battleHandler = GetComponent<BattlesHandler>();
        _mover = GetComponent<PlayerMover>();
        _shooter = GetComponent<Shooter>();
        _rotator = GetComponent<PlayerRotator>();

        _stateMachine = new PlayerStateMachine(_shooter, _battleHandler, _mover, _rotator, this);
    }

    private void Start() {
        _stateMachine.TranslateTo<PlayerMovingState>();
    }

    public void Shoot(Vector3 target) {
        _shooter.Shot(target);
    }
}