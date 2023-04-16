using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    private Vector3 _throwForceVec;
    private Vector3 _torqueForceVec;
    private float _minForceValue = 8.0f;
    private float _maxForceValue = 16.0f;
    private float _minTorqueValue = 0.2f;
    private float _maxTorqueValue = 2.0f;


    private void CreateRandomVectors()
    {
        // random values of force
        float throwForceX = Random.Range(Random.Range(-_maxForceValue, -_minForceValue), Random.Range(_minForceValue, _maxForceValue));
        float throwForceY = Random.Range(_minForceValue, _maxForceValue);
        float throwForceZ = Random.Range(Random.Range(-_maxForceValue, -_minForceValue), Random.Range(_minForceValue, _maxForceValue));

        // random values of torque
        float torqueForceX = Random.Range(Random.Range(-_maxTorqueValue, -_minTorqueValue), Random.Range(_minTorqueValue, _maxTorqueValue));
        float torqueForceY = Random.Range(Random.Range(-_maxTorqueValue, -_minTorqueValue), Random.Range(_minTorqueValue, _maxTorqueValue));
        float torqueForceZ = Random.Range(Random.Range(-_maxTorqueValue, -_minTorqueValue), Random.Range(_minTorqueValue, _maxTorqueValue));

        // random vectors of force and torque
        _throwForceVec = new Vector3(throwForceX, throwForceY, throwForceZ);
        _torqueForceVec = new Vector3(torqueForceX, torqueForceY, torqueForceZ);
    }//CreateRandomVectors


    public void ThrowDice()
    {
        CreateRandomVectors();
        gameObject.GetComponent<Rigidbody>().AddForce(_throwForceVec, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddTorque(_torqueForceVec, ForceMode.Impulse);
    }//ThrowDice
}//Class