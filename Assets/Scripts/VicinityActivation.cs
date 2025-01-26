using System;
using UnityEngine;
using UnityEngine.Events;

public class VicinityActivation : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public bool isWithin = false;

    private void OnTriggerEnter(Collider other) {
        isWithin = true;
        onEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other) {
        isWithin = false;
        onExit?.Invoke();
    }
}
