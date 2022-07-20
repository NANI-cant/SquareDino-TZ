using System;
using System.Collections.Generic;

public class PlayerStateMachine : StateMachine {

    public PlayerStateMachine(Shooter shooter, BattlesHandler battleHandler, PlayerMover mover, PlayerRotator rotator, PlayerBehaviour player) {
        _states = new Dictionary<Type, State> {
            [typeof(PlayerShootingState)] = new PlayerShootingState(this, shooter, rotator, battleHandler),
            [typeof(PlayerMovingState)] = new PlayerMovingState(this, mover, battleHandler, player),
        };
    }
}
