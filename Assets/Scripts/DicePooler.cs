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
        }
    }
    public List<DiceType> diceTypes;
    //public Dictionary<string, Queue<GameObject>> poolDictionary;


    public Queue<GameObject> dicePool;



    private void Start()
    {
        //poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // seçilen tag'a sahip DiceType'ı bulunur
        DiceType type = diceTypes.Find(d => d.tag == DiceManager.chosenDiceType);

        // seçilen tag'a sahip DiceModel'i bulunur
        DiceType.DiceModel pool = type.models.Find(p => p.tag == DiceManager.chosenDice);

        // DiceModel'dan prefab kullanılarak GameObject'ler initiate edilir ve queue'ya eklenir
        dicePool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab, transform);
            obj.SetActive(false);
            dicePool.Enqueue(obj);
        }

        // queue, poolDictionary'e eklenir
        //poolDictionary.Add(pool.tag, dicePool);
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject dice = GetPooledDice();
            dice.transform.position = Vector3.zero;
            dice.transform.rotation = Quaternion.identity;
            dice.SetActive(true);
        }
    }


    public GameObject GetPooledDice()
    {
        
        GameObject dice = dicePool.Dequeue();

        return dice;
    }


}// class
