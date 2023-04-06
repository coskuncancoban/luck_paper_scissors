using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{

    private float throwForceX;
    private float throwForceY;
    private float throwForceZ;
    private float torqueForceX;
    private float torqueForceY;
    private float torqueForceZ;
    private Vector3 throwForceVec;
    private Vector3 torqueForceVec;
    private float minForceValue = 8.0f;
    private float maxForceValue = 16.0f;
    private float minTorqueValue = 0.2f;
    private float maxTorqueValue = 2.0f;
    public static bool isThrown;



    void Start()
    {
        isThrown = false;
        
        Debug.Log("Zar nesnesinin RigidBody verisi çekildi");

    }// Start


    void Update()
    {
        // Throws the dices when press Space
        if (Input.GetKeyDown(KeyCode.Space) && !isThrown )
        {
            Debug.Log("Space tuşuna basıldı");
            ThrowDice();
        }

    }// Update


    public void CreateRandomVectors()
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
        Debug.Log("Random fırlatma ve döndürme vektörleri oluşturuldu");

    }// CreateRandomVectors


    public void ThrowDice()
    {
        CreateRandomVectors();
        Rigidbody diceRb = this.gameObject.GetComponent<Rigidbody>();
        diceRb.AddForce(throwForceVec, ForceMode.Impulse);
        diceRb.AddTorque(torqueForceVec, ForceMode.Impulse);

        isThrown = true;
        Debug.Log("Zar fırlatıldı");

    }// ThrowDice

}// Class