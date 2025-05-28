using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{

    private int currentXP;
    private int currentLevel = 1;
    public static LevelManager instance;
    public UnityEvent <int> levelGained;
    public UnityEvent<float> xpGained;

    private void Awake()
    {
        instance = this;
    }

    public void GiveXP(int xpToGive)
    {
        currentXP += xpToGive;
        Debug.Log("current XP: " + currentXP);
        CalculateLevel();
    }

    private void CalculateLevel()
    {
        int xpToNextLevel = currentLevel * 100;
        xpGained.Invoke((float)currentXP / (float)xpToNextLevel);
        if(currentXP >= xpToNextLevel)
        {
            currentLevel++;
            currentXP -= xpToNextLevel;
            levelGained.Invoke(currentLevel);
            CalculateLevel();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
