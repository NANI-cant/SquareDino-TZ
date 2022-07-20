using UnityEngine;

public class Battle : MonoBehaviour {
    [SerializeField] private Transform _wayPoint;
    [SerializeField] private EnemyBehaviour[] _enemies;

    public Transform WayPoint => _wayPoint;
    public EnemyBehaviour[] Enemies => _enemies;

    private void Awake() {
        if (_wayPoint == null) Debug.LogException(new System.Exception($"{this}: {nameof(_wayPoint)} is null"));
    }
}
