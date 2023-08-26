using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }

    // Constants
    private static readonly string KEY_HIGHEST_SCORE = "HighestScore";

    // API
    public bool isGameOver { get; private set; }
    [Header("Audio")]
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource gameOverSFX;

    [Header("Score")]
    [SerializeField] private float score;
    [SerializeField] private int highestScore;

    [Header("Game Over")]
    [Tooltip("Time until game restarts.")]
    public float reloadSceneCooldown = 6f;
    [Tooltip("The closest to 1, the quicker game ends. 0 means no Sudden Death")]
    public float suddenDeathRatio = 1f;

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // Score
        score = 0;
        highestScore = PlayerPrefs.GetInt(KEY_HIGHEST_SCORE);
    }

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            // Increment score
            score += Time.fixedDeltaTime;

            // Update highest score
            if (GetScore() > GetHighestScore())
            {
                highestScore = GetScore();
            }
        }
    }

    public int GetScore()
    {
        return (int)Mathf.Floor(score);
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void EndGame()
    {
        if (isGameOver) return;

        // Set flag
        isGameOver = true;

        // Stop music
        musicPlayer.Stop();

        // Play SFX
        gameOverSFX.Play();

        // Save highest score
        PlayerPrefs.SetInt(KEY_HIGHEST_SCORE, GetHighestScore());

        // Reload scene
        StartCoroutine(ReloadScene(reloadSceneCooldown));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // Wait
        yield return new WaitForSeconds(delay);

        // Reload scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
