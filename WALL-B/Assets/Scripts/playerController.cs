using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int maxJumps;

    [Header("UI")]
    [SerializeField] private GameObject thruster;

    [Header("Transforms")]
    [SerializeField] Transform rightForceThruster;
    [SerializeField] Transform leftForceThruster;
    [SerializeField] Transform rightThruster;
    [SerializeField] Transform leftThruster;
    [SerializeField] Transform smokeSpawn;
    [SerializeField] Rigidbody2D character;

    [Header("Values")]
    [SerializeField] float sideThrusterForce;
    [SerializeField] float bottomThrusterForce;
    [SerializeField] float bigSideThrusterForce;

    [Header("Prefabs")]
    [SerializeField] private GameObject smoke;
    [SerializeField] private GameObject thrusterSmoke;
    [SerializeField] private GameObject bonkEffect;
    [SerializeField] private GameObject deathEffect;

    [Header("animators")]
    [SerializeField] private Animator leftAni;
    [SerializeField] private Animator middleAni;
    [SerializeField] private Animator rightAni;

    [Header("Audio")]
    [SerializeField] private FMODUnity.EventReference thrustAudio;
    [SerializeField] private FMODUnity.EventReference fallAudio;
    [SerializeField] private FMODUnity.EventReference deathAudio;

    [Header("Tab Cam")]
    [SerializeField] private GameObject isHere;
    [SerializeField] private GameObject cameraOverlay;

    private bool isBigThrust;
    private bool canMove = true;
    private bool youareHere = false;
    private Vector3 oldPosition;
    private float timeElapsed;
    private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        isBigThrust = false;
        timeElapsed = 0;
        jumpsLeft = maxJumps;
        isHere.SetActive(youareHere);

    }

    // Update is called once per frame
    void Update()
    {

        if (!canMove)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            character.AddForceAtPosition(character.transform.right * (isBigThrust? bigSideThrusterForce : sideThrusterForce), leftForceThruster.position, ForceMode2D.Impulse);
            Instantiate(thrusterSmoke, leftThruster.position, Random.rotation);
            FMODUnity.RuntimeManager.PlayOneShot(thrustAudio);
            leftAni.SetTrigger("fire");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            character.AddForceAtPosition(-character.transform.right * (isBigThrust ? bigSideThrusterForce : sideThrusterForce), rightForceThruster.position, ForceMode2D.Impulse);
            Instantiate(thrusterSmoke, rightThruster.position, Random.rotation);
            FMODUnity.RuntimeManager.PlayOneShot(thrustAudio);
            rightAni.SetTrigger("fire");
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            character.AddForce(character.transform.up * bottomThrusterForce, ForceMode2D.Impulse);
            middleAni.SetTrigger("fire");
            jumpsLeft--;
            if (jumpsLeft<=0)
            {
                thruster.SetActive(false);
            }
            Instantiate(smoke, smokeSpawn.position, Random.rotation);
            FMODUnity.RuntimeManager.PlayOneShot(thrustAudio);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FMODUnity.RuntimeManager.PlayOneShot(deathAudio);
            RespawnManager.Instance.StartRespawn();
        }

        //Do tab cam
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            youareHere = !youareHere;
            isHere.SetActive(youareHere);
            cameraOverlay.SetActive(youareHere);
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
            thruster.SetActive(true);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isBigThrust = true;
        jumpsLeft = maxJumps;
        thruster.SetActive(true);
        Instantiate(bonkEffect, transform.position, Random.rotation);
        FMODUnity.RuntimeManager.PlayOneShot(fallAudio);
    }

    public void resetJumps()
    {
        jumpsLeft = maxJumps;
        thruster.SetActive(true);
    }

    public void DisableMovement()
    {
        canMove = false;
    }
}
