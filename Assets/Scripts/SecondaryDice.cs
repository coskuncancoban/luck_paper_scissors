using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryDice : MonoBehaviour
{
    private bool _isThrown = false;
    private bool _isChecked = false;
    private Rigidbody _rb;
    private bool _onGround = false;
    private void Start()
    {
        GetComponent<DiceThrower>().ThrowDice();
    }



    private void Update()
    {
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
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _onGround = true;
        }
    }
}
