using UnityEngine;

public class PlayerAvatar : MonoBehaviour {
    [SerializeField] private Animator _animator;

    private const string RUNNINGKEY = "Running";

    public void SetRunning() {
        Debug.Log("A");
        _animator.SetBool(RUNNINGKEY, true);
    }
    public void SetIdle() {
        Debug.Log("B");
        _animator.SetBool(RUNNINGKEY, false);
    }
}