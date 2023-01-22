using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    private Rigidbody diceRb;

    private float throwForceX;
    private float throwForceY;
    private float throwForceZ;

    private float torqueForceX;
    private float torqueForceY;
    private float torqueForceZ;
    private float tolerance = 10.0f;

    private bool onGround = false;
    private bool wrongLanded = false;

    // Start is called before the first frame update
    void Start()
    {
        diceRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Random values of throw and torque
        throwForceX = Random.Range(Random.Range(-16.0f, -8.0f), Random.Range(8.0f, 16.0f));
        throwForceY = Random.Range(8.0f, 16.0f);
        throwForceZ = Random.Range(Random.Range(-16.0f, -8.0f), Random.Range(8.0f, 16.0f));

        torqueForceX = Random.Range(Random.Range(-2.0f, -0.2f), Random.Range(0.2f, 2f));
        torqueForceY = Random.Range(Random.Range(-2.0f, -0.2f), Random.Range(0.2f, 2f));
        torqueForceZ = Random.Range(Random.Range(-2.0f, -0.2f), Random.Range(0.2f, 2f));

        ThrowDice();
    }

    private void FixedUpdate()
    {
        if (diceRb.IsSleeping() && onGround)
        {
            //Debug.Log("Dice is sleeping on ground");
            CheckDice();
        }
    }

    public void ThrowDice()
    {
        //Random vectors of force and torque
        Vector3 throwForceVec = new Vector3(throwForceX, throwForceY, throwForceZ);
        Vector3 torqueForceVec = new Vector3(torqueForceX, torqueForceY, torqueForceZ);

        if (Input.GetKeyDown(KeyCode.Space) || wrongLanded)
        {
            diceRb.AddForce(throwForceVec, ForceMode.Impulse);
            diceRb.AddTorque(torqueForceVec, ForceMode.Impulse);
            //Debug.Log("torque = " + torqueForceVec);
            //Debug.Log("throw = " + throwForceVec);
            wrongLanded = false;
        }
    }

    public void CheckDice()
    {

        Vector3 eulerAngles = transform.eulerAngles;
        //Debug.Log(eulerAngles);

        // zarın yukarı baktığı yüzeyin belirlenmesi
        if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && 180.0f - tolerance < eulerAngles.z && eulerAngles.z < 180.0f + tolerance)
        {
            Debug.Log("Zar yüzeyi 1 yukarıda");
        }
        else if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && (270.0f - tolerance < eulerAngles.z && eulerAngles.z < 270.0f + tolerance))
        {
            Debug.Log("Zar yüzeyi 2 yukarıda");
        }
        else if (270.0f - tolerance < eulerAngles.x && eulerAngles.x < 270.0f + tolerance && -tolerance < eulerAngles.z && eulerAngles.z < tolerance)
        {
            Debug.Log("Zar yüzeyi 3 yukarıda");
        }
        else if (90.0f - tolerance < eulerAngles.x && eulerAngles.x < 90.0f + tolerance && -tolerance < eulerAngles.z && eulerAngles.z < tolerance)
        {
            Debug.Log("Zar yüzeyi 4 yukarıda");
        }
        else if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && 90.0f - tolerance < eulerAngles.z && eulerAngles.z < 90.0f + tolerance)
        {
            Debug.Log("Zar yüzeyi 5 yukarıda");
        }
        else if (-tolerance < eulerAngles.x && eulerAngles.x < tolerance && -tolerance < eulerAngles.z && eulerAngles.z < tolerance)
        {
            Debug.Log("Zar yüzeyi 6 yukarıda");
        }
        else
        {
            //wrongLanded = true;
            Debug.Log("Landed wrongly");
            Debug.Log(eulerAngles);
            Debug.Log("x = " + eulerAngles.x + "y = " + eulerAngles.y + "z = " + eulerAngles.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

}
