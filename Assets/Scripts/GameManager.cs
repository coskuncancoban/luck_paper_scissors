using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string chosenDiceType = "d6";
    public string chosenDice = "s_portal";
    public bool secondaryDices = false;

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
        }//DiceModel
    }//DiceType
    public List<DiceType> diceTypes;
    private GameManager _gameManagerScript;

    public GameObject chosenDicePrefab;





    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }



    private void Start()
    {
        // find the chosen dice type
        DiceType type = diceTypes.Find(d => d.tag == chosenDiceType);

        // find the chosen dice model
        DiceType.DiceModel model = type.models.Find(p => p.tag == chosenDice);

        // find the prefab of the chosen dice model
        chosenDicePrefab = model.prefab;
    }//Start



}
