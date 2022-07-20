using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour {
    public event Action Arrived;

    private int _currentPointIndex;
    private NavMeshAgent _aiAgent;

    public PlayerMover Initialize(float movementSpeed) {
        _aiAgent = GetComponent<NavMeshAgent>();
        _aiAgent.speed = movementSpeed;

        return this;
    }

    private void Update() {
        if (Mathf.Approximately(_aiAgent.remainingDistance, 0) && !_aiAgent.pathPending) {
            Arrived?.Invoke();
        }
    }

    public void MoveTo(Vector3 position) => _aiAgent.destination = position;
}
