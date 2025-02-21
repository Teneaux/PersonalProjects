using UnityEngine;
using TMPro;

public class PointUIScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PointManager pointManager;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text maximumScoreText;
    [SerializeField] private TMP_Text wreakageRatingText;
    [SerializeField] private TMP_Text bankText;

    void Start()
    {
        maximumScoreText.text = pointManager.GetMaximumPointAmount().ToString();
        pointManager.OnCurrentScoreChange += PointManager_OnCurrentScoreChange;
        highScoreText.text = pointManager.GetHighScore().ToString();
        if(wreakageRatingText != null)
        {
            wreakageRatingText.text = GameManager.Instance.GetWreakageRating().ToString();
        }
        if(bankText != null)
        {
            bankText.text = GameManager.Instance.GetBank().ToString();
        }
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
