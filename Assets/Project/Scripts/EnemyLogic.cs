using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float speed = 2f;
    public bool isLeft;

    public int enemyHp = 3;

    private void Start()
    {
        if(transform.position.x < 0) isLeft = true;
        else isLeft = false;
    }
    void Update()
    {
        if (enemyHp <= 0) Destroy(gameObject);

        if (isLeft) transform.Translate(Vector2.right * speed * Time.deltaTime);
        else transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
