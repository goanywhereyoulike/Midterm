using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayhud : MonoBehaviour
{
    [SerializeField]
    private Text scoresText=null;

    [SerializeField]
    private Text timeText=null;

    [SerializeField]
    private Text MessageText=null;


    [SerializeField]
    private Slider healthbar = null;


    public void Initialize()
    {
        MessageText.text = string.Empty;
        scoresText.text = "0";
        timeText.text = "Time: " + "0";
        healthbar.maxValue = 1;
        healthbar.value = 1;

    }

    public void SetGameplayHUDActive(bool shouldbeActive)
    {
        gameObject.SetActive(shouldbeActive);

    }

    public void UpdateScores(int currentScore)
    {

        scoresText.text = currentScore.ToString();

    }

    public void UpdateMessageText(string text)
    {
        MessageText.gameObject.SetActive(true);
        MessageText.text = text;

    }

    public void UpdateTimeText(float time)
    {
        timeText.text = "Time: " + time;

    }
    public void SetHealthBar(float maxHealth)
    {
        healthbar.maxValue = maxHealth;

    }
    public void UpdateHealthBar(float health)
    {

        healthbar.value = health;
    }
}
