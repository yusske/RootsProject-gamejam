using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int time = 30;
    public int gameDifficulty = 1;
    public bool gameOver;

    [SerializeField] int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.UpdateUIScore(score);
            if (score % 1000 == 0)
                gameDifficulty++;

        }
    }
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(CountDownRime());
    }
    IEnumerator CountDownRime()
    {
        while (time > 0)
        {
            UIManager.Instance.UpdateUITime(time);
            yield return new WaitForSeconds(1);
            time--;

        }
        gameOver = true;
        UIManager.Instance.ShowGameOverScreen();

    }

    public void PlayAgain(){
        SceneManager.LoadScene("Game");
    }
}
