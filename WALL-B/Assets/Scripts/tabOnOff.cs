using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabOnOff : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        ui.SetActive(on);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            on = !on;
            ui.SetActive(on);
        }
    }
}
