using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int startingLives = 3;
    private int currentLives;

    public TMP_Text livesText;
    public GameSceneManage sceneManage;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            currentLives = startingLives;
            UpdateLivesUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();
        if (currentLives <= 0)
        {
            // Game Over logic, reset level or handle game over state
            sceneManage.EndScreen();
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives.ToString();
        }
    }
}
