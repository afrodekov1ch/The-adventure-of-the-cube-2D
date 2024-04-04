using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{
    public GameObject winGamePanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (winGamePanel != null)
            {
                winGamePanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}