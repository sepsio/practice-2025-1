using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;              // Средняя скорость движения
    public float moveDistance = 3f;       // Расстояние от начальной позиции в обе стороны

    private Vector3 startPosition;
    private bool movingLeft = true;       // Изначально враг смотрит влево и движется влево

    void Start()
    {
        startPosition = transform.position;
        // Убедимся, что враг изначально смотрит влево
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * -1;  // Отзеркалим по X для левого направления
        transform.localScale = scale;
    }

    void Update()
    {
        if (movingLeft)
        {
            // Двигаемся влево
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Проверяем, не вышли ли за левую границу
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingLeft = false;
                Flip();
            }
        }
        else
        {
            // Двигаемся вправо
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Проверяем, не вышли ли за правую границу
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingLeft = true;
                Flip();
            }
        }
    }

    // Метод для зеркального отражения спрайта по оси X
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
