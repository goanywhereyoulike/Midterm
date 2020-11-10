using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject hudPrefab = null;
    private GamePlayhud _hud = null;
    private void Awake()
    {
        if (hudPrefab == null)
        {
            Debug.Log("UIManager has no hud prefab assigned");
        }
        
        GameLoader.CallOnComplete(Initialize);

    }

    public void Initialize()
    {
        var hudProject = Instantiate(hudPrefab);

        hudProject.transform.SetParent(transform);

        _hud = hudProject.GetComponent<GamePlayhud>();
        if (_hud == null)
        {
            Debug.Log("Gameplay hud is null");
            return;
        }
        _hud.Initialize();
        StartCoroutine(TimeAdd());
    }

    public void UpdateScoreDisplay(int currentStore)
    {
        _hud.UpdateScores(currentStore);

    }

    public void DisplayMessageText(string message)
    {
        _hud.UpdateMessageText(message);
    }
    public void SetHealthBar(float maxHealth)
    {
        _hud.SetHealthBar(maxHealth);

    }
    public void UpdateHealthBar(float health)
    {

        _hud.UpdateHealthBar(health);
    }

    private float time = 0.0f;
    public float Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
            UPdateTimeDisplay();
        }
    }
    public void UPdateTimeDisplay()
    {
        _hud.UpdateTimeText(Time);
    }

   
    //bool EndUiactive = false;

    //[SerializeField]
    //private Text pointsText;

    //[SerializeField]
    //private Text timeText;

    //[SerializeField]
    //private Text EndText;


    //public void SetEndUi(int state)
    //{
    //    EndUiactive = true;
    //    if (state == 2)
    //    {
    //        EndText.text = "YOU WIN";
    //        SetUI();


    //    }
    //    else if (state == 1)
    //    {
    //        EndText.text = "Next Level";
    //        SetUI();
    //    }
    //    else if (state == 0)
    //    {
    //        EndText.text = "YOU LOSE";
    //        SetUI();
    //    }
    //    EndUiactive = false;
    //}

    //public void SetUI()
    //{
    //    EndText.gameObject.SetActive(EndUiactive);
    //}

    private IEnumerator TimeAdd()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Time++;
        }
    }
}
