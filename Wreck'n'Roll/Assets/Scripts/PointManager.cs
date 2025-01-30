using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class PointManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private List<DamageableObjects> damageableObjectInScene = new List<DamageableObjects>();
    [SerializeField] private int currentScore;
    [SerializeField] private int maximumPointAmount;
    [SerializeField] private int highScore;

    public event EventHandler OnCurrentScoreChange;

    void Awake()
    {
        foreach(DamageableObjects x in FindObjectsByType<DamageableObjects>(FindObjectsSortMode.None))
        {
            damageableObjectInScene.Add(x);
        }

        foreach(DamageableObjects y in damageableObjectInScene)
        {
            maximumPointAmount += y.MyMaxHP();
        }
        
        //make highscore = highscore of this level from previous plays
    }

    private void Start()
    {
        foreach(DamageableObjects damageableObject in damageableObjectInScene)
        {
            damageableObject.OnObjectDeath += DamageableObject_OnObjectDeath;
        }

        
    }

    private void DamageableObject_OnObjectDeath(object sender, DamageableObjects.OnObjectDeathArgs e)
    {
        currentScore += e.maxHpPoints;
        OnCurrentScoreChange?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentPointAmount()
    {
        return currentScore;
    }

    public int GetMaximumPointAmount()
    {
        return maximumPointAmount;
    }
}
