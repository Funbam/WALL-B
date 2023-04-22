using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnLocation;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RespawnManager.Instance.currentRespawn = this;
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnLocation);
    }
}
