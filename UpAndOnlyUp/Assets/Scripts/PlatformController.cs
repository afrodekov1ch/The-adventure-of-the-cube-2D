using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical }

    public MovementType movementType;
    public float speed = 5f;
    public float range = 20f;
    public bool moveWithPlayer = true;

    private Vector3 initialPosition;
    private float direction = 1f;
    private Collision2D lastCollision; // Переменная для хранения последнего столкновения с игроком

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (movementType == MovementType.Horizontal)
        {
            float horizontalMovement = direction * speed * Time.deltaTime;
            transform.Translate(horizontalMovement, 0f, 0f);

            if (Mathf.Abs(transform.position.x - initialPosition.x) >= range)
            {
                direction *= -1f;
            }
        }
        else if (movementType == MovementType.Vertical)
        {
            float verticalMovement = direction * speed * Time.deltaTime;
            transform.Translate(0f, verticalMovement, 0f);

            if (Mathf.Abs(transform.position.y - initialPosition.y) >= range)
            {
                direction *= -1f;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (moveWithPlayer && collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (moveWithPlayer && collision.gameObject.CompareTag("Player"))
        {
            lastCollision = collision; // Сохраняем последнее столкновение с игроком
            Invoke("ResetParent", 0f); // Вызов ResetParent() с нулевой задержкой
        }
    }

    private void ResetParent()
    {
        if (lastCollision != null && lastCollision.gameObject.CompareTag("Player"))
        {
            lastCollision.transform.SetParent(null); // Снимаем игрока с платформы
            lastCollision = null; // Обнуляем последнее столкновение
        }
    }
}