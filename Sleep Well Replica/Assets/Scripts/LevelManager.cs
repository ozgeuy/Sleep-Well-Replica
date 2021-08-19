using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int Level = 1;

    public TextController TextController;

    [SerializeField] private GameObject[] levels;





    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
