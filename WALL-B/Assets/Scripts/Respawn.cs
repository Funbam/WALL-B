using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject activateEffect;
    [SerializeField] private Transform spawnLocation;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RespawnManager.Instance.currentRespawn = this;
        Instantiate(activateEffect, transform.position, Quaternion.identity);
    }

    public void RespawnPlayer()
    {
        GameObject go = Instantiate(playerPrefab, spawnLocation.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("camera").GetComponent<CinemachineVirtualCamera>().Follow = go.transform;
    }
}
