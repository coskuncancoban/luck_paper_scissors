using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    private Rigidbody diceRb;
    public GameObject dicePrefab;
    private float throwForceX;
    private float throwForceY;
    private float throwForceZ;
    private float torqueForceX;
    private float torqueForceY;
    private float torqueForceZ;
    private Vector3 throwForceVec;
    private Vector3 torqueForceVec;
    private int upFace = 0;
    private float tolerance = 10.0f;
    private float minForceValue = 8.0f;
    private float maxForceValue = 16.0f;
    private float minTorqueValue = 0.2f;
    private float maxTorqueValue = 2.0f;
    private bool onGround = false;
    private bool wrongLanded = false;
    private bool diceThrowed = false;


    void Start()
    {
        diceRb = GetComponent<Rigidbody>();
    }// Start


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || wrongLanded)
        {
            CreateRandomVectors();
            ThrowDice();
        }
    }// Update


    private void FixedUpdate()
    {
        if (diceRb.IsSleeping() && onGround && diceThrowed)
        {
            CheckDice();
            diceThrowed = false;
        }

        if (upFace != 0)
        {
            InstantiateDice();
            upFace = 0;
        }
    }// Fixed Update


    private void CreateRandomVectors()
    {
        // Random values of force
        throwForceX = Random.Range(Random.Range(-maxForceValue, -minForceValue), Random.Range(minForceValue, maxForceValue));
        throwForceY = Random.Range(minForceValue, maxForceValue);
        throwForceZ = Random.Range(Random.Range(-maxForceValue, -minForceValue), Random.Range(minForceValue, maxForceValue));

        // Random values of torque
        torqueForceX = Random.Range(Random.Range(-maxTorqueValue, -minTorqueValue), Random.Range(minTorqueValue, maxTorqueValue));
        torqueForceY = Random.Range(Random.Range(-maxTorqueValue, -minTorqueValue), Random.Range(minTorqueValue, maxTorqueValue));
        torqueForceZ = Random.Range(Random.Range(-maxTorqueValue, -minTorqueValue), Random.Range(minTorqueValue, maxTorqueValue));

        // Random vectors of force and torque
        throwForceVec = new Vector3(throwForceX, throwForceY, throwForceZ);
        torqueForceVec = new Vector3(torqueForceX, torqueForceY, torqueForceZ);
    }


    public void ThrowDice()
    {
        diceRb.AddForce(throwForceVec, ForceMode.Impulse);
        diceRb.AddTorque(torqueForceVec, ForceMode.Impulse);
        diceThrowed = true;

        wrongLanded = false;
    }// ThrowDice


    public void CheckDice()
    {
        // Checking the dice which face is up
        Vector3 eulerAngles = transform.eulerAngles;

        if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && 180.0f - tolerance < eulerAngles.z && eulerAngles.z < 180.0f + tolerance)
        {
            upFace = 1;
            Debug.Log("Face 1 is up");
        }
        else if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && (270.0f - tolerance < eulerAngles.z && eulerAngles.z < 270.0f + tolerance))
        {
            upFace = 2;
            Debug.Log("Face 2 is up");
        }
        else if (270.0f - tolerance < eulerAngles.x && eulerAngles.x < 270.0f + tolerance && -tolerance < eulerAngles.z && eulerAngles.z < tolerance)
        {
            upFace = 3;
            Debug.Log("Face 3 is up");
        }
        else if (90.0f - tolerance < eulerAngles.x && eulerAngles.x < 90.0f + tolerance && -tolerance < eulerAngles.z && eulerAngles.z < tolerance)
        {
            upFace = 4;
            Debug.Log("Face 4 is up");
        }
        else if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && 90.0f - tolerance < eulerAngles.z && eulerAngles.z < 90.0f + tolerance)
        {
            upFace = 5;
            Debug.Log("Face 5 is up");
        }
        else if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && -tolerance < eulerAngles.z && eulerAngles.z < tolerance)
        {
            upFace = 6;
            Debug.Log("Face 6 is up");
        }
        else
        {
            // The dice did not correctly landed
            wrongLanded = true;
        }
    }// CheckDice


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }// OnCollusionEnter


    private void InstantiateDice()
    {
        for (int i = 0; i < upFace; i++)
        {
            GameObject secondaryDice = Instantiate(dicePrefab, gameObject.transform.position, Quaternion.identity);
            Rigidbody secondaryDiceRb = secondaryDice.GetComponent<Rigidbody>();
            secondaryDiceRb.AddForce(throwForceVec, ForceMode.Impulse);
            secondaryDiceRb.AddTorque(torqueForceVec, ForceMode.Impulse);
        }
        diceThrowed = false;
    }


}// Class