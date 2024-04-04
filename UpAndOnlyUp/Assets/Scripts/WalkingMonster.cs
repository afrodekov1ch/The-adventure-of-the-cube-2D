using UnityEngine;

public class WalkingMonster : Game.Entity
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float moveDistance = 3.0f;
    private Vector3 direction;
    private SpriteRenderer sprite;
    private Vector3 initialPosition;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        direction = transform.right;
    }

    private void Move()
    {
        // Вычисляем конечную точку движения
        Vector3 endPosition = initialPosition + direction * moveDistance;

        // Если монстр достиг конечной точки, меняем направление
        if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
        {
            ChangeDirection();
        }

        // Двигаем монстра
        transform.position += direction * speed * Time.deltaTime;
        sprite.flipX = direction.x > 0.0f;
    }

    private void ChangeDirection()
    {
        direction = -direction;
    }

    private void Update()
    {
        Move();
    }

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