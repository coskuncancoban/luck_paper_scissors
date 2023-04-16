using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceChecker : MonoBehaviour
{
    private float _tolerance = 10.0f;
    public int upFace;
    public bool wrongLanded = false;
    private GameManager _gameManagerScript;

    private void Start()
    {
        _gameManagerScript = GameManager.Instance;
    }


    public void CheckDice()
    {
        Vector3 eulerAngles = transform.eulerAngles;

        switch (_gameManagerScript.chosenDiceType)
        {
            case "d4":

                break;

            case "d6":
                if (-_tolerance < eulerAngles.x && eulerAngles.x < _tolerance && 180.0f - _tolerance < eulerAngles.z && eulerAngles.z < 180.0f + _tolerance)
                {
                    upFace = 1;
                    Debug.Log("Face 1 is up");
                }
                else if (-_tolerance < eulerAngles.x && eulerAngles.x < _tolerance && (270.0f - _tolerance < eulerAngles.z && eulerAngles.z < 270.0f + _tolerance))
                {
                    upFace = 2;
                    Debug.Log("Face 2 is up");
                }
                else if (270.0f - _tolerance < eulerAngles.x && eulerAngles.x < 270.0f + _tolerance && -_tolerance < eulerAngles.z && eulerAngles.z < _tolerance)
                {
                    upFace = 3;
                    Debug.Log("Face 3 is up");
                }
                else if (90.0f - _tolerance < eulerAngles.x && eulerAngles.x < 90.0f + _tolerance && -_tolerance < eulerAngles.z && eulerAngles.z < _tolerance)
                {
                    upFace = 4;
                    Debug.Log("Face 4 is up");
                }
                else if (-_tolerance < eulerAngles.x && eulerAngles.x < _tolerance && 90.0f - _tolerance < eulerAngles.z && eulerAngles.z < 90.0f + _tolerance)
                {
                    upFace = 5;
                    Debug.Log("Face 5 is up");
                }
                else if (-_tolerance < eulerAngles.x && eulerAngles.x < _tolerance && -_tolerance < eulerAngles.z && eulerAngles.z < _tolerance)
                {
                    upFace = 6;
                    Debug.Log("Face 6 is up");
                }
                else
                {
                    Debug.Log("The dice did not correctly landed");
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
                Debug.Log("Something went wrong. The dice does not have any 'dice type'.");
                break;
        }
    }//CheckDice
}//Class
