using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Hero player = collision.gameObject.GetComponent<Hero>();
            if (player != null)
            {
                player.GetDamage();
            }
        }
    }
}