using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PointManager Instance{get; private set;}


    private static string HIGHSCORE_TAG = "HighScore";
    [SerializeField] private List<DamageableObjects> damageableObjectInScene = new List<DamageableObjects>();
    [SerializeField] private int currentScore;
    [SerializeField] private int maximumPointAmount;
    [SerializeField] private int highScore;
    [SerializeField] private GameObject roundEndScreen;
    [SerializeField] private List<Ball> allBalls = new List<Ball>();

    public event EventHandler OnCurrentScoreChange;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one PointManager");
        }
        Instance = this;
        
        highScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + HIGHSCORE_TAG);
        
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

    public int GetHighScore()
    { 
        return highScore; 
    }

    public void AddABall(Ball ball)
    {
        allBalls.Add(ball);
        ball.OnBallDeath += Ball_OnBallDeath;
    }

    private void Ball_OnBallDeath(object sender, EventArgs e)
    {
        if (allBalls.Count >= 0) 
        {
            roundEndScreen.SetActive(true);
            if(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + HIGHSCORE_TAG) < currentScore)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + HIGHSCORE_TAG, currentScore);
            }
        }
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
