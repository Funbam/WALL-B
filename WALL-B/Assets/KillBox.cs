using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
