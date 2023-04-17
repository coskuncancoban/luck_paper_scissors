using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryDice : MonoBehaviour
{
    private bool _isThrown = false;
    private bool _isChecked = false;
    private Rigidbody _rb;
    private bool _onGround = false;
    private bool _secondaryDices = false;



    private void Update()
    {
        // if i press space and the dice is not thrown, throw it
        if (Input.GetKeyDown(KeyCode.Space) && !_isThrown)
        {
            _isThrown = true;
            GetComponent<DiceThrower>().ThrowDice();
            Debug.Log("Dice thrown");
        }

        // if the dice is thrown, sleeping and "not on ground", throw it again
        if (_isThrown && GetComponent<Rigidbody>().IsSleeping() && !_onGround)
        {
            GetComponent<DiceThrower>().ThrowDice();
        }

        // if the dice is thrown, sleeping and on ground, check it
        if (_isThrown && GetComponent<Rigidbody>().IsSleeping() && _onGround && !_isChecked)
        {
            _isChecked = true;
            GetComponent<DiceChecker>().CheckDice();

            // if the dice wrong landed, throw it again and reset the checker
            if (GetComponent<DiceChecker>().wrongLanded)
            {
                GetComponent<DiceThrower>().ThrowDice();
                _isChecked = false;
                GetComponent<DiceChecker>().wrongLanded = false;
            }
        }

        if (_isChecked && !_secondaryDices)
        {

            StartCoroutine(InstantiateDice());

            _secondaryDices = true;
        }
    }//Update

    IEnumerator InstantiateDice()
    {
        int upFace = GetComponent<DiceChecker>().upFace;
        for (int i = 0; i < upFace; i++)
        {
            GameObject dice = GetComponent<DiceInstantiater>().InstantiateDice();
            yield return new WaitForSeconds(0.12f);
        }
        Destroy(gameObject);
    }//InstantiateDice


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _onGround = true;
        }
    }
}//Class
