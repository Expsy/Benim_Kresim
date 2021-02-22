using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using  TMPro;

public class BalloonUIManager : MonoBehaviour
{
    public static BalloonUIManager instance;
    public TMP_Text pointsText;
    private BalloonManager balloonManager;

    public Stat reflex;
    public Stat control;
    public Stat accuracy;

    public GameObject statsScreen;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        balloonManager = BalloonManager.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        pointsText.text = balloonManager.points.ToString();
    }

    public void UpdateStats()
    {
        StartCoroutine(UpdateStatsCoroutine());
    }

    public IEnumerator UpdateStatsCoroutine()
    {
        statsScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        reflex.StartTweens(balloonManager.reflexAverage);
        control.StartTweens(balloonManager.control);
        accuracy.StartTweens(balloonManager.accuracy);
    }
}
