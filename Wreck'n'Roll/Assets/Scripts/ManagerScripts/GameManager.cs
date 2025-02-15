using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static string WRECKAGE_RATING_KEY = "wreckageRating";
    private static string BANK_KEY = "bank";
    private static string SCENE_NAME_LEVEL_SELECTION = "LevelSelect";
    private static string SCENE_NAME_HOME_SCREEN = "HomeScreen";
    private static string SCENE_NAME_JOES_SCENE = "Joe's Scene";


    private int wreakageRating;
    private int bank;
    
    
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is anotehr instance of GameManager in the Scene");
        }
        Instance = this;
        wreakageRating = PlayerPrefs.GetInt(WRECKAGE_RATING_KEY);
        bank = PlayerPrefs.GetInt(BANK_KEY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateWreakageRating(int score) 
    {
        PlayerPrefs.SetInt(WRECKAGE_RATING_KEY, PlayerPrefs.GetInt(WRECKAGE_RATING_KEY) + score);
    }
    public void UpdateBank(int score)
    {
        PlayerPrefs.SetInt(BANK_KEY, PlayerPrefs.GetInt(BANK_KEY) + score);
    }

    public void Play()
    {
        SceneManager.LoadScene(SCENE_NAME_LEVEL_SELECTION);
    }

    public void Home()
    {
        SceneManager.LoadScene(SCENE_NAME_HOME_SCREEN);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SCENE_NAME_JOES_SCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
