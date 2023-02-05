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
    AudioSource[] allAudios;


    [SerializeField] int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.UpdateUIScore(score);
            if (score % 10000 == 0)
            {    
                gameDifficulty+=1.0f;
                updateAudio();
            }
        }
    }
    private void updateAudio(){
    if (gameDifficulty > 8.0f){
            allAudios[0].Stop();
            allAudios[1].Stop();
             if(!allAudios[2].isPlaying) allAudios[2].Play();
        }
        else if (gameDifficulty > 4.0f){
            allAudios[0].Stop();
             if(!allAudios[1].isPlaying) allAudios[1].Play();
            allAudios[2].Stop();
        } else {
            if(!allAudios[0].isPlaying) allAudios[0].Play();
            allAudios[1].Stop();
            allAudios[2].Stop();
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
        allAudios = Camera.main.gameObject.GetComponents<AudioSource>();
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
