using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInstantiater : MonoBehaviour
{
    private GameManager _gameManagerScript;

    private void Start()
    {
        _gameManagerScript = GameManager.Instance;
    }//Start


    public GameObject InstantiateDice()
    {
        GameObject dice = Instantiate(_gameManagerScript.chosenDicePrefab, transform.position, Quaternion.identity);
        return dice;
    }//InstantiateDice
    
}
