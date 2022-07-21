using System;
using UnityEngine;

public class Battle : MonoBehaviour {
    [SerializeField] private Transform _wayPoint;
    [SerializeField] private EnemyBehaviour[] _enemies;

    public Transform WayPoint => _wayPoint;
    public EnemyBehaviour[] Enemies => _enemies;

    private void Awake() {
        if (_wayPoint == null) Debug.LogException(new System.Exception($"{this}: {nameof(_wayPoint)} is null"));
    }

    public void DisableEnemies() {
        foreach (var enemy in _enemies) {
            enemy.Health.Disable();
        }
    }

    public void EnableEnemies() {
        foreach (var enemy in _enemies) {
            enemy.Health.Enable();
        }
    }
}
