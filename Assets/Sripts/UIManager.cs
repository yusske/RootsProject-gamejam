using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance;
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;
    [SerializeField] Text timeText;
    [SerializeField] Text finalScoreText;
    [SerializeField] GameObject gameOverScreen;

private void Awake(){
    if(Instance == null){
        Instance = this;
    }
}
    public void UpdateUIScore(int newScore){
        scoreText.text = newScore.ToString();
    }

    public void UpdateUIHealth(int newHealth){
        healthText.text = newHealth.ToString();
    }

    public void UpdateUITime(int newTime){
        timeText.text = newTime.ToString();
    }

    public void ShowGameOverScreen(){
        gameOverScreen.SetActive(true);
        finalScoreText.text = "Score: " + GameManager.Instance.Score;
    }

}
