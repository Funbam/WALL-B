using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Windows.WebCam;

public class TabCam : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera tabCam;

    private int currentPriority = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentPriority == -1)
            {
                currentPriority = 100;
            }
            else
            {
                currentPriority = -1;
            }

            tabCam.Priority = currentPriority;
        }
    }


}
