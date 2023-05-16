using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enableSelect : MonoBehaviour
{
    public Button select;
    
    private void OnEnable()
    {
        select.Select();
    }
}
