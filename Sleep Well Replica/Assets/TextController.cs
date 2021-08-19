using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{


    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text missionText;

    [SerializeField] private string[] levelMissions;

    private int Iterator;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void SetTexts()
    {
        Iterator = (LevelManager.Instance.Level - 1);
        levelText.text = "LEVEL " + LevelManager.Instance.Level;
        missionText.text = levelMissions[Iterator];

    }
}
