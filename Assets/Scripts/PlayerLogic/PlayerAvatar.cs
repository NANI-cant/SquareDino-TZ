using UnityEngine;

public class PlayerAvatar : MonoBehaviour {
    [SerializeField] private Animator _animator;

    private const string RUNNINGKEY = "Running";

    public void SetRunning() => _animator.SetBool(RUNNINGKEY, true);
    public void SetIdle() => _animator.SetBool(RUNNINGKEY, false);
}