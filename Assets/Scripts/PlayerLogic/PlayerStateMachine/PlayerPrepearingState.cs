public class PlayerPrepearingState : State {
    private PlayerStateMachine _stateMachine;
    private GameLifeCycle _gameLifeCycle;

    public PlayerPrepearingState(PlayerStateMachine stateMachine, GameLifeCycle gameLifeCycle) {
        _stateMachine = stateMachine;
        _gameLifeCycle = gameLifeCycle;
    }

    public override void Enter() => _gameLifeCycle.Started += OnGameStart;
    public override void Exit() => _gameLifeCycle.Started -= OnGameStart;

    private void OnGameStart() => _stateMachine.TranslateTo<PlayerMovingState>();
}
