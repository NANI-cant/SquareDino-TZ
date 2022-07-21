using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {
    private Rigidbody[] _bones;
    // private List<Collider> _colliders = new List<Collider>();

    private void Awake() {
        _bones = GetComponentsInChildren<Rigidbody>();

        // foreach (var bone in _bones) {
        //     if (bone.TryGetComponent<Collider>(out Collider collider)) {
        //         _colliders.Add(collider);
        //     }
        // }

        Disable();
    }

    public void Fall() {
        Enable();
    }

    private void Enable() {
        foreach (var bone in _bones) {
            bone.isKinematic = false;
        }
        // foreach (var collider in _colliders) {
        //     collider.enabled = true;
        // }
    }

    private void Disable() {
        foreach (var bone in _bones) {
            bone.isKinematic = true;
        }
        // foreach (var collider in _colliders) {
        //     collider.enabled = false;
        // }
    }
}