using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerInput : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _hitable;

    private const float MAXDISTANCE = 100f;

    private PlayerBehaviour _character;

    private void Awake() {
        _character = GetComponent<PlayerBehaviour>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Vector3 target = Vector3.zero;
            if (Physics.Raycast(ray, out RaycastHit hitInfo, MAXDISTANCE, _hitable)) {
                target = hitInfo.point;
            }
            else {
                target = ray.origin + ray.direction * MAXDISTANCE;
            }
            _character.Shoot(target);
        }
    }
}
