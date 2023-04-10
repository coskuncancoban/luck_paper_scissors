using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCaller : MonoBehaviour
{

    private DicePooler dicePoolerScript;
    private DiceManager diceManagerScript;
    private Vector3 _position;

    private void Start()
    {
        diceManagerScript = GameObject.Find("DiceManager").GetComponent<DiceManager>();
        dicePoolerScript = GameObject.Find("DiceManager").GetComponent<DicePooler>();
    }//Start

    private void Update()
    {
        if (diceManagerScript.upFace != 0 && !diceManagerScript.secondaryDices)
        {
            _position = gameObject.transform.position;
            
            
            StartCoroutine(CallDices());
            diceManagerScript.secondaryDices = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            diceManagerScript.isChecked = false;
            
        }
    }

    IEnumerator CallDices()
    {
        for (int i = 0; i < diceManagerScript.upFace; i++)
        {
            GameObject dice = dicePoolerScript.GetPooledDice();
            dice.transform.position = _position;
            dice.SetActive(true);
            yield return new WaitForSeconds(0.16f);
        }
        Destroy(gameObject);
        Debug.Log("Secondary dices are created and first dice destroyed");
    }//CallDices
}//Class
