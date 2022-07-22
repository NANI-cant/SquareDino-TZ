using System;
using UnityEngine.SceneManagement;

public class GameLifeCycle {
    public event Action Started;

    public void Start() {
        Started?.Invoke();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}