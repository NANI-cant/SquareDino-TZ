using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour {
    private void Awake() {
        PlayerBehaviour player = Bootstrapper.GetInstance<PlayerBehaviour>();

        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;
    }
}
