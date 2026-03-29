using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float timer = 0f;
    public GameObject finalScreenOne;
    public GameObject finalScreenTwo;
    public GameObject finalText;

    private int currentLevel = 1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(finalScreenOne);
        DontDestroyOnLoad(finalScreenTwo);
        DontDestroyOnLoad(finalText);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 180)
        {
            finalScreenOne.SetActive(true);
        }
        else if(timer > 120 && currentLevel == 2)
        {
            currentLevel = 3;
            SceneManager.LoadScene("Level3");
        }
        else if(timer > 60 && currentLevel == 1)
        {
            currentLevel = 2;
            SceneManager.LoadScene("Level2");
        }
    }
}
