using System;
using System.Collections.Generic;

public class PlayerStateMachine : StateMachine {

    public PlayerStateMachine(Shooter shooter, BattlesHandler battleHandler, PlayerMover mover, PlayerRotator rotator, PlayerBehaviour player, GameLifeCycle gameLifeCycle, PlayerAvatar avatar) {
        _states = new Dictionary<Type, State> {
            [typeof(PlayerPrepearingState)] = new PlayerPrepearingState(this, gameLifeCycle, avatar),
            [typeof(PlayerShootingState)] = new PlayerShootingState(this, shooter, rotator, battleHandler, avatar, gameLifeCycle),
            [typeof(PlayerMovingState)] = new PlayerMovingState(this, mover, battleHandler, player, avatar),
        };
    }
}
