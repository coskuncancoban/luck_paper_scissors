using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryDice : MonoBehaviour
{
    private bool _isChecked = false;
    private Rigidbody _rb;
    private bool _onGround = false;
    private bool _coin = false;



    private void OnEnable()
    {
        GetComponent<DiceThrower>().ThrowDice();
    }//OnEnable



    private void Update()
    {
        // if the dice is sleeping and "not on ground", throw it again
        if (GetComponent<Rigidbody>().IsSleeping() && !_onGround)
        {
            GetComponent<DiceThrower>().ThrowDice();
        }

        // if the dice is sleeping and on ground, check it
        if (GetComponent<Rigidbody>().IsSleeping() && _onGround && !_isChecked)
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

        if (GetComponent<DiceChecker>().upFace != 0 && !_coin)
        {
            GetComponent<CoinInstantiater>().InstantiateCoin();
            _coin = true;
            Destroy(gameObject);
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
