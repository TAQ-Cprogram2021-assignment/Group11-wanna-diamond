using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionPoint : MonoBehaviour
{
    public enum TransitionType
    {
        sameScene,
        DifferentScene
    }

    public TransitionType tranSitionType;
    public string sceneName;
    public TransitionDestination.DestinationTag destinationTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
