public class PlayerMovingState : State {
    private PlayerMover _mover;
    private PlayerStateMachine _stateMachine;
    private BattlesHandler _battleHandler;
    private PlayerBehaviour _player;

    public PlayerMovingState(PlayerStateMachine stateMachine, PlayerMover mover, BattlesHandler battleHandler, PlayerBehaviour player) {
        _stateMachine = stateMachine;
        _mover = mover;
        _battleHandler = battleHandler;
        _player = player;
    }

    public override void Enter() {
        _mover.MoveTo(_battleHandler.CurrentWayPoint.position);
        _mover.Arrived += OnArrived;
    }

    private void OnArrived() {
        _mover.Arrived -= OnArrived;
        _battleHandler.OnArrived(_player);
        _stateMachine.TranslateTo<PlayerShootingState>();
    }
}
