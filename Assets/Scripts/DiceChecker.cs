using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceChecker : MonoBehaviour
{
    private Rigidbody diceRb;
    private DiceThrower diceThrowerScript;
    //private Instantiate instantiateScript;
    private float tolerance = 10.0f;
    public static int upFace = 0;
    private bool onGround = false;
    public bool wrongLanded = false;
    private string diceTag;
    public bool isChecked = false;



    // Start is called before the first frame update
    void Start()
    {
        diceTag = gameObject.tag;
        diceRb = GetComponent<Rigidbody>();
        diceThrowerScript = GetComponent<DiceThrower>();
    }// Start


    private void FixedUpdate()
    {
        
        // Throws the dice if wrongLanded or sleeping, throwed and not onGround
        if (wrongLanded || (diceRb.IsSleeping() && DiceThrower.isThrown && !onGround))
        {
            diceThrowerScript.ThrowDice();
            wrongLanded = false;
        }

        // Checks the Dice if sleeping and onGround
        if (diceRb.IsSleeping() && onGround && !isChecked)
        {
            CheckTheDices();
        }


    }// FixedUpdate





    public void CheckTheDices()
    {

        // Checking the dice which face is up
        Vector3 eulerAngles = transform.eulerAngles;

        switch (diceTag)
        {
            case "d4":

                break;

            case "d6":
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

                break;

            case "d8":

                break;

            case "d10":

                break;

            case "d12":

                break;

            case "d20":

                break;


            default:
                Debug.Log("Something went wrong. The dice does not have any face tag!");
                break;

        }

        Debug.Log("Zar Kontrol Edildi");
        isChecked = true;


    }//CheckDice


    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground") && DiceThrower.isThrown )
        {
            onGround = true;
        }
    }// OnCollusionEnter



}
