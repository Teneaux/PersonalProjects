using UnityEngine;
using TMPro;

public class PointUIScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PointManager pointManager;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text maximumScoreText;
    void Start()
    {
        maximumScoreText.text = pointManager.GetMaximumPointAmount().ToString();
        pointManager.OnCurrentScoreChange += PointManager_OnCurrentScoreChange;
        highScoreText.text = pointManager.GetHighScore().ToString();
    }

    private void PointManager_OnCurrentScoreChange(object sender, System.EventArgs e)
    {
        currentScoreText.text = pointManager.GetCurrentPointAmount().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
