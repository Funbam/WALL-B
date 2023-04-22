using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Transform rightThruster;
    [SerializeField] Transform leftThruster;
    [SerializeField] Rigidbody2D character;
    [SerializeField] float sideThrusterForce;
    [SerializeField] float bottomThrusterForce;
    [SerializeField] float bigSideThrusterForce;

    private bool isBigThrust;
    private Vector3 oldPosition;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        isBigThrust = false;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            character.AddForceAtPosition(character.transform.right * (isBigThrust? bigSideThrusterForce : sideThrusterForce), leftThruster.position, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            character.AddForceAtPosition(-character.transform.right * (isBigThrust ? bigSideThrusterForce : sideThrusterForce), rightThruster.position, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.AddForce(character.transform.up * bottomThrusterForce, ForceMode2D.Impulse);
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
    }
}
