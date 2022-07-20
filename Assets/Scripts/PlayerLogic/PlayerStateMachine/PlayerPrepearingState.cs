public class PlayerPrepearingState : State {
    private PlayerStateMachine _stateMachine;
    private GameLifeCycle _gameLifeCycle;
    private PlayerAvatar _avatar;

    public PlayerPrepearingState(PlayerStateMachine stateMachine, GameLifeCycle gameLifeCycle, PlayerAvatar avatar) {
        _stateMachine = stateMachine;
        _gameLifeCycle = gameLifeCycle;
        _avatar = avatar;
    }

    public override void Enter() {
        _avatar.SetIdle();
        _gameLifeCycle.Started += OnGameStart;
    }

    public override void Exit() => _gameLifeCycle.Started -= OnGameStart;

    private void OnGameStart() => _stateMachine.TranslateTo<PlayerMovingState>();
}
