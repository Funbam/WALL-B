using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unrotate : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.parent.rotation.z * -1.0f);

    }
}
