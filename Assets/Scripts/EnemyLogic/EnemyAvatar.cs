using UnityEngine;

public class EnemyAvatar : MonoBehaviour {
    [Header("Dev")]
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private Animator _animator;

    [ContextMenu("Fall")]
    public void Fall() {
        _animator.enabled = false;
        _ragdoll.Fall();
    }
}
