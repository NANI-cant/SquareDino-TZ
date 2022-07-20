using System.Collections;
using UnityEngine;

public class PlayerRotator : MonoBehaviour {
    [Header("Metrics")]
    [SerializeField] private float _timeForRotation = 0.2f;

    private Transform _transform;

    private void Awake() {
        _transform = transform;
    }

    public void RotateToEnemies(EnemyBehaviour[] enemies) {
        Vector3 direction = CalculateTargetDirection(enemies);
        StartCoroutine(RotateSmoothly(direction));
    }

    private IEnumerator RotateSmoothly(Vector3 targetDirection) {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion startRotation = _transform.rotation;

        float progress = 0;
        while (progress < 1) {
            progress += 1 / _timeForRotation * Time.deltaTime;
            _transform.rotation = Quaternion.Lerp(startRotation, targetRotation, progress);
            yield return new WaitForEndOfFrame();
        }
    }

    private Vector3 CalculateTargetDirection(EnemyBehaviour[] enemies) {
        if (enemies.Length == 0) return Vector3.zero;

        Bounds enemyBounds = enemies[0].GetComponent<Collider>().bounds;
        for (int i = 1; i < enemies.Length; i++) {
            enemyBounds.Encapsulate(enemies[i].GetComponent<Collider>().bounds);
        }

        Vector3 direction = (enemyBounds.center - transform.position).normalized;
        direction.y = transform.position.y;
        direction.Normalize();

        return direction;
    }
}
