using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private int lives = 1;
    [SerializeField] private float jumpForce = 6f;
    
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private GameManager gameManager;
    private Vector3 respawnPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        respawnPosition = transform.position;
    }

    private void FixedUpdate()
    {
        CheckGround();
        if (isGrounded && Input.GetButton("Jump"))
            Jump();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        Debug.Log("Jumping");
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        isGrounded = hit.collider != null;
        Debug.Log("Grounded: " + isGrounded);
    }

    private void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        gameManager.gameOverPanel.SetActive(true);
        Respawn();
    }

    private void Respawn()
    {
        transform.position = respawnPosition;
    }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log("Remaining lives: " + lives);
        if (lives <= 0)
        {
            ShowGameOverPanel();
        }
    }
}