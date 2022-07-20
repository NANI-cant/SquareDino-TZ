using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour {
    [SerializeField] private PlayerBehaviour _player;

    private void Awake() {
        _player.transform.position = transform.position;
        _player.transform.rotation = transform.rotation;
    }
}
