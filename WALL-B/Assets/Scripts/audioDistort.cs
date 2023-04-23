using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDistort : MonoBehaviour
{
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
    }
}