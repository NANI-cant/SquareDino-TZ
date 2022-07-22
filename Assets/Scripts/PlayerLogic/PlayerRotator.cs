using System.Collections;
using UnityEngine;

public class PlayerRotator : MonoBehaviour {
    private float _timeForRotation = 0.2f;
    private Transform _transform;

    public PlayerRotator Initialize(float timeForRotation) {
        _transform = transform;
        _timeForRotation = timeForRotation;

        return this;
    }

    public void RotateToEnemies(EnemyBehaviour[] enemies) {
        Vector3 direction = CalculateTargetDirection(enemies);
        StartCoroutine(RotateSmoothly(direction));
    }

    private IEnumerator RotateSmoothly(Vector3 targetDirection) {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
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

        Bounds enemyBounds = enemies[0].Bounds;
        for (int i = 1; i < enemies.Length; i++) {
            enemyBounds.Encapsulate(enemies[i].Bounds);
        }

        Vector3 direction = (enemyBounds.center - transform.position).normalized;
        direction.y = 0;
        direction.Normalize();

        return direction;
    }
}
