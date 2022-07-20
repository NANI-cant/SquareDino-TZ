using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour {

    public event Action Arrived;

    private int _currentPointIndex;
    private NavMeshAgent _aiAgent;

    private void Awake() {
        _aiAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (Mathf.Approximately(_aiAgent.remainingDistance, 0)) {
            Arrived?.Invoke();
        }
    }

    public void MoveTo(Vector3 position) => _aiAgent.SetDestination(position);
}
