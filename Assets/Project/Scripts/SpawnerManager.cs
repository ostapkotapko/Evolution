using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject spawnPointLeft;
    public GameObject spawnPointRight;
    public GameObject enemyPrefab;

    public float delay = 0f;
    public int whereSpawn; // 0 - left, 1 - right

    private void Update()
    {
        delay += Time.deltaTime;
        if (delay > 5f)
        {
            whereSpawn = Random.Range(0, 2);
            if (whereSpawn == 0)
            {
                enemyPrefab.GetComponent<SpriteRenderer>().flipX = false;
                Instantiate(enemyPrefab, spawnPointLeft.transform.position, Quaternion.identity);
            }
            else if (whereSpawn == 1)
            {
                enemyPrefab.GetComponent<SpriteRenderer>().flipX = true;
                Instantiate(enemyPrefab, spawnPointRight.transform.position, Quaternion.identity);
            }
            delay = 0f;
        }
    }
}
