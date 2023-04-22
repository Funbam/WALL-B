using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colObj = collision.gameObject;
        if(colObj.tag == playerTag)
        {
            Instantiate(deathEffect, colObj.transform.position, Quaternion.identity);
            Destroy(colObj);
            RespawnManager.Instance.StartRespawn();
        }
    }
}
