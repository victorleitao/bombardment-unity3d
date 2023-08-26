
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI highestScoreLabel;
    [SerializeField] private TextMeshProUGUI newGameCooldown;
    [SerializeField] private GameObject gameOverScreen;
    private float restartCooldown;

    void Start()
    {
        scoreLabel.text = GameManager.Instance.GetScore().ToString();
        highestScoreLabel.text = GameManager.Instance.GetHighestScore().ToString();
        restartCooldown = GameManager.Instance.reloadSceneCooldown;
    }

    void FixedUpdate()
    {
        scoreLabel.text = GameManager.Instance.GetScore().ToString();
        highestScoreLabel.text = GameManager.Instance.GetHighestScore().ToString();

        if (GameManager.Instance.isGameOver)
        {
            gameOverScreen.SetActive(true);
            newGameCooldown.text = "Restarting in " + Mathf.Ceil(restartCooldown -= Time.fixedDeltaTime) + "...";
        }
    }
}
