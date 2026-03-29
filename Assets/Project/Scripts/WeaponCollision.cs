using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public bool weaponOnEnemy = false;
    public GameObject currEnemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyLogic>() != null)
        {
            currEnemy = other.gameObject;
            weaponOnEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<EnemyLogic>() != null)
        {
            currEnemy = other.gameObject;
            weaponOnEnemy = false;
        }
    }
}
