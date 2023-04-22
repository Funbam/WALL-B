using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int maxJumps;

    [Header("Transforms")]
    [SerializeField] Transform rightThruster;
    [SerializeField] Transform leftThruster;
    [SerializeField] Transform smokeSpawn;
    [SerializeField] Rigidbody2D character;

    [Header("Values")]
    [SerializeField] float sideThrusterForce;
    [SerializeField] float bottomThrusterForce;
    [SerializeField] float bigSideThrusterForce;

    [Header("Prefabs")]
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject thrusterSmoke;
    [SerializeField] GameObject bonkEffect;

    private bool isBigThrust;
    private Vector3 oldPosition;
    private float timeElapsed;
    private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        isBigThrust = false;
        timeElapsed = 0;
        jumpsLeft = maxJumps;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            character.AddForceAtPosition(character.transform.right * (isBigThrust? bigSideThrusterForce : sideThrusterForce), leftThruster.position, ForceMode2D.Impulse);
            Instantiate(thrusterSmoke, leftThruster.position, Random.rotation);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            character.AddForceAtPosition(-character.transform.right * (isBigThrust ? bigSideThrusterForce : sideThrusterForce), rightThruster.position, ForceMode2D.Impulse);
            Instantiate(thrusterSmoke, rightThruster.position, Random.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            character.AddForce(character.transform.up * bottomThrusterForce, ForceMode2D.Impulse);
            jumpsLeft--;
            Instantiate(smoke, smokeSpawn.position, Random.rotation);
        }

        //Deal with being stuck
        if (Mathf.Approximately(transform.position.x, oldPosition.x) && Mathf.Approximately(transform.position.y, oldPosition.y))
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
            oldPosition = transform.position;
        }

        if (!isBigThrust && timeElapsed >= 0.5f)
        {
            isBigThrust = true;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isBigThrust = true;
        jumpsLeft = maxJumps;
        Instantiate(bonkEffect, transform.position, Random.rotation);
    }

    public void resetJumps()
    {
        jumpsLeft = maxJumps;
    }
}
