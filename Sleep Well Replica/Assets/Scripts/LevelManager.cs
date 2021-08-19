using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int Level = 1;

    public TextController TextController;

    [SerializeField] private GameObject[] levels;

    private GameObject currentLevel;





    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
       currentLevel = Instantiate(levels[Level - 1]);
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetLevel()
    {
        
        currentLevel.SetActive(false);
        Level++;
        TextController.SetTexts(); //LEVEL NUMBER AND MISSION TEXTS
        //levels[Level - 1].SetActive(true);
        GameObject newLevel = Instantiate(levels[Level - 1]);
    }
}
