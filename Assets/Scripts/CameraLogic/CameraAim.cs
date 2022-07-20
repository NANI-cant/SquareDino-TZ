using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAim : MonoBehaviour {
    [SerializeField] private Transform _followIt;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;

    private Transform _transform;

    private void Awake() {
        _transform = transform;
    }

    private void Update() {
        _transform.position = _followIt.TransformPoint(_positionOffset);
        _transform.forward = _followIt.forward;
        _transform.Rotate(_rotationOffset, Space.Self);
    }

#if UNITY_EDITOR
    private void OnValidate() {
        transform.position = _followIt.TransformPoint(_positionOffset);
        transform.forward = _followIt.forward;
        transform.Rotate(_rotationOffset, Space.Self);
    }
#endif
}
