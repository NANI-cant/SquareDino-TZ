using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour {
    private void Start() {
        PlayerBehaviour player = Bootstrapper.GetInstance<PlayerBehaviour>();

        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;
    }
}
