using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDistort : MonoBehaviour
{
    public TabCam TabCam; 
    public Distortion distorition;
    [SerializeField] FMODUnity.EventReference music;
    private FMOD.Studio.EventInstance instance;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(music);
        instance.start();
    }


    void Update()
    {
        instance.setParameterByName("Distort", distorition.distortionPercent);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (TabCam.currentPriority == -1)
            {
                instance.setParameterByName("ToggleBad", 1);
            }
            else
            {
                instance.setParameterByName("ToggleBad", 0);
            }

        }
    }
}