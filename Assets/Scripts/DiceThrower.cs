using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    private Vector3 throwForceVec;
    private Vector3 torqueForceVec;
    private float minForceValue = 8.0f;
    private float maxForceValue = 16.0f;
    private float minTorqueValue = 0.2f;
    private float maxTorqueValue = 2.0f;
    private DiceManager diceManagerScript;

    private void OnEnable()
    {
        diceManagerScript = GameObject.Find("DiceManager").GetComponent<DiceManager>();
        if(diceManagerScript.isThrowed)
        {
            ThrowDice();
        }
    }


    void Update()
    {
        // throws the dices when press Space
        if (diceManagerScript.wrongLanded || (Input.GetKeyDown(KeyCode.Space) && !diceManagerScript.isThrowed))
        {
            ThrowDice();
            Debug.Log("Dice throwed");
        }
    }//Update


    public void CreateRandomVectors()
    {
        // random values of force
        float throwForceX = Random.Range(Random.Range(-maxForceValue, -minForceValue), Random.Range(minForceValue, maxForceValue));
        float throwForceY = Random.Range(minForceValue, maxForceValue);
        float throwForceZ = Random.Range(Random.Range(-maxForceValue, -minForceValue), Random.Range(minForceValue, maxForceValue));

        // random values of torque
        float torqueForceX = Random.Range(Random.Range(-maxTorqueValue, -minTorqueValue), Random.Range(minTorqueValue, maxTorqueValue));
        float torqueForceY = Random.Range(Random.Range(-maxTorqueValue, -minTorqueValue), Random.Range(minTorqueValue, maxTorqueValue));
        float torqueForceZ = Random.Range(Random.Range(-maxTorqueValue, -minTorqueValue), Random.Range(minTorqueValue, maxTorqueValue));

        // random vectors of force and torque
        throwForceVec = new Vector3(throwForceX, throwForceY, throwForceZ);
        torqueForceVec = new Vector3(torqueForceX, torqueForceY, torqueForceZ);
    }//CreateRandomVectors


    public void ThrowDice()
    {
        CreateRandomVectors();
        Rigidbody diceRb = this.gameObject.GetComponent<Rigidbody>();
        diceRb.AddForce(throwForceVec, ForceMode.Impulse);
        diceRb.AddTorque(torqueForceVec, ForceMode.Impulse);
        diceManagerScript.isThrowed = true;
    }//ThrowDice

}//Class