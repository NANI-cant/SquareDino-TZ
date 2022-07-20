public class PlayerMovingState : State {
    private PlayerMover _mover;
    private PlayerStateMachine _stateMachine;
    private BattlesHandler _battleHandler;
    private PlayerBehaviour _player;
    private PlayerAvatar _avatar;

    public PlayerMovingState(PlayerStateMachine stateMachine, PlayerMover mover, BattlesHandler battleHandler, PlayerBehaviour player, PlayerAvatar avatar) {
        _stateMachine = stateMachine;
        _mover = mover;
        _battleHandler = battleHandler;
        _player = player;
        _avatar = avatar;
    }

    public override void Enter() {
        _avatar.SetRunning();
        _mover.MoveTo(_battleHandler.CurrentWayPoint.position);
        _mover.Arrived += OnArrived;
    }

    private void OnArrived() {
        _mover.Arrived -= OnArrived;
        _battleHandler.OnArrived(_player);
        _stateMachine.TranslateTo<PlayerShootingState>();
    }
}
