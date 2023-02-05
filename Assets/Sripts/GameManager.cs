using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int time = 0;
    [SerializeField] public int scoreByTime = 250;
    public float gameDifficulty = 1.0f;
    public bool gameOver;


    [SerializeField] int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.UpdateUIScore(score);
            if (score % 10000 == 0)
                gameDifficulty+=1.0f;

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
            yield return new WaitForSeconds(0.4f);
            time++;
            Score += scoreByTime;
        }
        //UIManager.Instance.ShowGameOverScreen();

    }

    public void PlayAgain(){
        SceneManager.LoadScene("Game");
    }
}
