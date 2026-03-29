using UnityEngine;

public class Base : MonoBehaviour
{
    public int hp = 5;
    public GameManager gameManager;

    private void Update()
    {
        if(hp <= 0)
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyLogic>() != null)
        {
            hp--;
            Destroy(other.gameObject);
        }
    }
}
