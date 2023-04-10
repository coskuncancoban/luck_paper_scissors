using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePooler : MonoBehaviour
{
    [System.Serializable]
    public struct DiceType
    {
        public string tag;
        public List<DiceModel> models;

        [System.Serializable]
        public struct DiceModel
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }//DiceModel
    }//DiceType
    public List<DiceType> diceTypes;
    private Queue<GameObject> _dicePool;
    private DiceManager _diceManagerScript;


    private void Start()
    {
        _diceManagerScript = gameObject.GetComponent<DiceManager>();
        
        // find the chosen dice type
        DiceType type = diceTypes.Find(d => d.tag == _diceManagerScript.chosenDiceType);

        // find the chosen dice model
        DiceType.DiceModel pool = type.models.Find(p => p.tag == _diceManagerScript.chosenDice);

        // create the dice pool
        _dicePool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab, transform);
            obj.SetActive(false);
            _dicePool.Enqueue(obj);
        }
    }//Start


    public GameObject GetPooledDice()
    {
        GameObject dice = _dicePool.Dequeue();
        return dice;
    }//GetPooledDice
}//Class
