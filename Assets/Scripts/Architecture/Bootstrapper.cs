using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private BattlesHandler _battlesHandler;
    [SerializeField] private PlayerBehaviour _player;

    private static Dictionary<Type, object> _container;

    private void Awake() {
        Bootstrap();
    }

    public static T GetInstance<T>() {
        if (_container.ContainsKey(typeof(T))) {
            return (T)_container[typeof(T)];
        }
        Debug.LogException(new Exception($"{nameof(Bootstrapper)}: {nameof(T)} is null"));
        return default(T);
    }

    public void Bootstrap() {
        _container = new Dictionary<Type, object>();

        _container[typeof(BattlesHandler)] = _battlesHandler;
        _container[typeof(PlayerBehaviour)] = _player;
        _container[typeof(GameLifeCycle)] = new GameLifeCycle();
    }
}
