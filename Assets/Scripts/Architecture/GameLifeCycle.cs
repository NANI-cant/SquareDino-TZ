using System;

public class GameLifeCycle {
    public event Action Started;

    public void Start() {
        Started?.Invoke();
    }
}