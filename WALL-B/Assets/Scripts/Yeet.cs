using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeet : MonoBehaviour
{
    [SerializeField] private float maxThrust;
    [SerializeField] private float yeetInterval;
    [SerializeField] private float discreteMod;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private GameObject bonkEffect;

    [SerializeField] private FMODUnity.EventReference fallAudio;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(YeetRoutine());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        FMODUnity.RuntimeManager.PlayOneShot(fallAudio);
        Instantiate(bonkEffect, transform.position, Random.rotation);
    }


    private IEnumerator YeetRoutine()
    {
        while (true)
        {
            Vector2 direction = new Vector2((float)Random.Range(-1, 1), (float)Random.Range(-1, 1));

            while(direction == Vector2.zero)
            {
                direction = new Vector2((float)Random.Range(-1, 1), (float)Random.Range(-1, 1));
            }

            float force = (float)Random.Range(-maxThrust, maxThrust);
            player.AddForce(force * direction * discreteMod);
            yield return new WaitForSeconds(yeetInterval);
        }
    }
}
