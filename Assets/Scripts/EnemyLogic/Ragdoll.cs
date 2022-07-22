using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {
    private Rigidbody[] _bones;

    private void Awake() {
        _bones = GetComponentsInChildren<Rigidbody>();

        Disable();
    }

    public void Fall() => Enable();

    private void Enable() {
        foreach (var bone in _bones) {
            bone.isKinematic = false;
        }
    }

    private void Disable() {
        foreach (var bone in _bones) {
            bone.isKinematic = true;
        }
    }
}