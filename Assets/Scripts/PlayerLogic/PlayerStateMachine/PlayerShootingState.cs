using UnityEngine.SceneManagement;

public class PlayerShootingState : State {
    private Shooter _shooter;
    private PlayerRotator _rotator;
    private BattlesHandler _battleHandler;
    private PlayerStateMachine _stateMachine;
    private PlayerAvatar _avatar;
    private GameLifeCycle _gameLifeCycle;

    public PlayerShootingState(PlayerStateMachine stateMachine, Shooter shooter, PlayerRotator rotator, BattlesHandler battleHandler, PlayerAvatar avatar, GameLifeCycle gameLifeCycle) {
        _stateMachine = stateMachine;
        _shooter = shooter;
        _rotator = rotator;
        _battleHandler = battleHandler;
        _avatar = avatar;
        _gameLifeCycle = gameLifeCycle;
    }

    public override void Enter() {
        _avatar.SetIdle();
        _rotator.RotateToEnemies(_battleHandler.CurrentEnemies);
        _battleHandler.BattleEnded += OnBattleEnded;
        _battleHandler.GameWon += OnGameWon;
        _shooter.Allow();
    }

    public override void Exit() {
        _shooter.Forbid();
        _battleHandler.BattleEnded -= OnBattleEnded;
        _battleHandler.GameWon -= OnGameWon;
    }

    private void OnBattleEnded() {
        _stateMachine.TranslateTo<PlayerMovingState>();
    }

    private void OnGameWon() {
        _gameLifeCycle.Restart();
    }
}
