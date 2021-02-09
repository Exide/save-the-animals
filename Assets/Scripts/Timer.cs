using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private DateTime startTime;
    
    private void Start() {
        startTime = DateTime.Now;
    }

    private void Update() {
    }

    private void OnGUI() {
        DateTime currentTime = DateTime.Now;
    }

}
