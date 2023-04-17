using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInstantiater : MonoBehaviour
{
    public GameObject coinPrefab;

    public GameObject InstantiateCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<PlayerController>().speed = GetComponent<DiceChecker>().upFace;
        return coin;
    }//InstantiateCoin
}
