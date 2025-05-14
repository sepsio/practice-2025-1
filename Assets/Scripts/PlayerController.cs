using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;            // Скорость движения
    public float jumpForce = 7f;        // Сила прыжка

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");  // Получаем ввод по горизонтали (-1, 0, 1)

        // Движение персонажа
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Прыжок при нажатии пробела и если персонаж на земле
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Зеркалирование персонажа в зависимости от направления движения
        if (moveX > 0)
            spriteRenderer.flipX = false;  // Спрайт смотрит вправо (исходное направление)
        else if (moveX < 0)
            spriteRenderer.flipX = true;   // Спрайт зеркалится и смотрит влево
    }

    // Проверка касания платформы для определения, можно ли прыгать
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
