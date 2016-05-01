﻿using UnityEngine;
using System.Collections;

public class SphereCommands : MonoBehaviour
{
    Vector3 originalPosition;

    //Use this for initialization
    void Start()
    {
        //Grab the original position of the sphere when the app starts
        originalPosition = this.transform.localPosition;
    }

    //Called by the GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        //If the sphere has no Rigidbody component, add one to enable physics
        if(!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    //Called by the SpeechManager when the user says the "Reset World" command
    void OnReset()
    {
        //If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if(rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }
        //Put the sphere back into its original local position
        this.transform.localPosition = originalPosition;
    }

    //Called by the SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        //Just do the same logic as a Select gesture
        OnSelect();
    }


}
