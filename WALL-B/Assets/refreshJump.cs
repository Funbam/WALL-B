using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refreshJump : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colObj = collision.gameObject;
        if (colObj.tag == "Player")
        {
            colObj.GetComponent<playerController>().resetJumps();
        }
    }
}
