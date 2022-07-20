using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool<T> where T : MonoBehaviour, IPoolable<T> {
    [SerializeField] private T _template;
    [SerializeField][Min(1)] private int _startSize = 1;
    [SerializeField] private Transform _container;

    private Queue<T> _freePool = new Queue<T>();
    private List<T> _activePool = new List<T>();
    private int _size = 1;

    public void Initialize() {
        Expand(_startSize);
    }
    public void Initialize(Transform container) {
        _container = container;
        Expand(_startSize);
    }

    private void Expand(int size) {
        for (int i = 0; i < size; i++) {
            var instance = GameObject.Instantiate(_template, _container);
            instance.gameObject.SetActive(false);
            _freePool.Enqueue(instance);
        }
        _size += size;
    }

    public T Take(Vector3 position, Quaternion rotation) {
        if (_freePool.Count == 0) {
            Expand(_size);
        }

        var instance = _freePool.Dequeue();
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.gameObject.SetActive(true);
        instance.Returned += OnReturned;

        _activePool.Add(instance);
        return instance;
    }

    public void Return(T instance) {
        instance.gameObject.SetActive(false);
        instance.Returned -= OnReturned;
        _activePool.Remove(instance);
        _freePool.Enqueue(instance);
    }

    public void ReturnAll() {
        foreach (var instance in _activePool) {
            instance.gameObject.SetActive(false);
            instance.Returned -= OnReturned;
            _freePool.Enqueue(instance);
        }
        _activePool.Clear();
    }

    private void OnReturned(T instance) => Return(instance);
}
