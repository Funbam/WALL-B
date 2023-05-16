using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Windows.WebCam;
using UnityEngine.InputSystem;

public class TabCam : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera tabCam;
    [SerializeField] FMODUnity.EventReference tabIn;
    [SerializeField] FMODUnity.EventReference tabOut;

    public PlayerControls pcs;
    private InputAction tab;

    public int currentPriority = -1;

    private void Awake()
    {
        pcs = new PlayerControls();

        tab = pcs.controls.map;

        tab.performed += tabBehavior =>
        {
            if (currentPriority == -1)
            {
                currentPriority = 100;
                FMODUnity.RuntimeManager.PlayOneShot(tabIn);
            }
            else
            {
                currentPriority = -1;
                FMODUnity.RuntimeManager.PlayOneShot(tabOut);
            }

            tabCam.Priority = currentPriority;
        };
    }

        private void OnEnable()
    {
        tab.Enable();
    }

    private void OnDisable()
    {
        tab.Disable();
    }


}
