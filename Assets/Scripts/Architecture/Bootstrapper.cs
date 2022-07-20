using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private BattlesHandler _battlesHandler;

    private static Dictionary<Type, object> _container;

    public BattlesHandler BattlesHandler => _battlesHandler;

    public static bool TryGetInstance<T>(out T instance) {
        if (_container.ContainsKey(typeof(T))) {
            instance = (T)_container[typeof(T)];
            return true;
        }
        instance = default(T);
        return false;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Bootstrap() {
        _container = new Dictionary<Type, object>();
        var instance = FindObjectOfType<Bootstrapper>();

        _container[typeof(BattlesHandler)] = instance.BattlesHandler;
        _container[typeof(GameLifeCycle)] = new GameLifeCycle();
    }
}
