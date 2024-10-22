﻿using UnityEngine;
using Vuforia;

public class markerDetected : MonoBehaviour, ITrackableEventHandler
{
    public GameObject promptWindow;

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //target is found
            Debug.Log("Detected: " + this.name);
            if (this.name == "Pfluger")
            {
                startQuiz.QuizNum = 1;
            }
            if (this.name == "Headwaters")
            {
                startQuiz.QuizNum = 2;
            }
            promptWindow.SetActive(true);
        }
        else
        {
            Debug.Log("Lost");
        }
    }
}

