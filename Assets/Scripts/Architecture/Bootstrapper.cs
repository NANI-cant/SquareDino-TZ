using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private BattlesHandler _battlesHandler;
    [SerializeField] private PlayerBehaviour _player;

    private static Dictionary<Type, object> _container;

    public BattlesHandler BattlesHandler => _battlesHandler;
    public PlayerBehaviour Player => _player;

    public static T GetInstance<T>() {
        if (_container.ContainsKey(typeof(T))) {
            return (T)_container[typeof(T)];
        }
        Debug.LogException(new Exception($"{nameof(Bootstrapper)}: {nameof(T)} is null"));
        return default(T);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Bootstrap() {
        _container = new Dictionary<Type, object>();
        var instance = FindObjectOfType<Bootstrapper>();

        _container[typeof(BattlesHandler)] = instance.BattlesHandler;
        _container[typeof(PlayerBehaviour)] = instance.Player;
        _container[typeof(GameLifeCycle)] = new GameLifeCycle();
    }
}
