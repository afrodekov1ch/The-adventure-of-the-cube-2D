using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int initialLives = 1;
    private int currentLives;
    public GameObject gameOverPanel;
    public Transform playerTransform;
    private Vector3 initialPlayerPosition;

    private void Start()
    {
        currentLives = initialLives;
        initialPlayerPosition = playerTransform.position;
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (playerTransform.position.y < initialPlayerPosition.y - 15f)
        {
            currentLives = 0;
            ShowGameOver();
        }
    }

    public void UpdateLives(int newLives)
    {
        currentLives = newLives;

        if (currentLives <= 0)
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        currentLives = initialLives;
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        playerTransform.position = initialPlayerPosition;
    }
}