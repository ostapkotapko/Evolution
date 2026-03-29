using UnityEngine;

public class FinalAnim : MonoBehaviour
{
    public GameObject finalScreenTwo;
    public GameObject finalText;

    public void EndAnim()
    {
        finalScreenTwo.SetActive(true);
        Invoke(nameof(FinalText), 2f);
    }

    public void FinalText()
    {
        finalText.SetActive(true);
        Time.timeScale = 0f;
    }
}
