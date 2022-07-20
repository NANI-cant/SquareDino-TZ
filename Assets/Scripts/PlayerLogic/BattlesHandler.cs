using System;
using UnityEngine;

public class BattlesHandler : MonoBehaviour {
    [SerializeField] private Battle[] _battles;

    public event Action BattleEnded;
    public event Action GameWon;

    private int _currentBattleIndex;
    private int _enemiesRemained;

    public Transform CurrentWayPoint => CurrentBattle.WayPoint;
    public EnemyBehaviour[] CurrentEnemies => CurrentBattle.Enemies;

    private Battle CurrentBattle => _battles[_currentBattleIndex];

    private void Awake() {
        _currentBattleIndex = 0;
    }

    public void OnArrived(PlayerBehaviour character) {
        _enemiesRemained = CurrentBattle.Enemies.Length;
        foreach (var enemy in CurrentBattle.Enemies) {
            enemy.Died += OnEnemieDied;
            enemy.Attack(character);
        }
        if (_enemiesRemained == 0) EndBattle();
    }

    private void OnEnemieDied() {
        _enemiesRemained--;
        if (_enemiesRemained == 0) EndBattle();
    }

    private void EndBattle() {
        _currentBattleIndex++;
        if (_currentBattleIndex == _battles.Length) {
            GameWon?.Invoke();
            return;
        }

        BattleEnded?.Invoke();
    }
}
