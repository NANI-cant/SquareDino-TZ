using System;
using UnityEngine;

public interface IPoolable<T> where T : MonoBehaviour {
    event Action<T> Returned;
}
