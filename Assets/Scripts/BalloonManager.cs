using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{

    public int difficulty = 0;
    public int maxDifficulty = 3;
    public float difficultyStepRate = 0.2f; //How often will it get harder
    public float difficultyStepTimer = 5; //How often will it get harder

    public List<float> reflexPointList = new List<float>();

    
    public List<Color32> balloonColors= new List<Color32>(){Constants.RED_BALLOON, Constants.BLUE_BALLOON, Constants.GREEN_BALLOON};
    
    #region Stats
    
    
    public float reflexAverage;
    
    public float totalBalloonsCount;
    public int missedBalloons;
    public float poppedBalloonsCount;
    
    public int missClick;

    public float accuracy;

    public float control;
    
    public int points;


    #endregion



    public bool gameIsOn = true; //is game ended or paused?

    private BalloonUIManager balloonUiManager;


    public static BalloonManager instance;

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
        balloonUiManager = BalloonUIManager.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOn)
        {
            HitOrMissCheck();
        }
    }

    public void EndGame()
    {
        gameIsOn = false;
        CalculateAccuracy();
        CalculateControl();
        CalculateReflex();
        balloonUiManager.UpdateStats();
    }

    private void CalculateReflex()
    {
        foreach (float reflexPoint in reflexPointList)
        {
            reflexAverage += reflexPoint;
        }

        if (reflexAverage != 0)
        {
            reflexAverage = reflexAverage / reflexPointList.Count;
        }
    }

    private void CalculateAccuracy()
    {
        if (missClick + poppedBalloonsCount != 0)
        {
            accuracy = poppedBalloonsCount / (missClick + poppedBalloonsCount);
        }
        else
        {
            accuracy = 0;
        }

    }

    private void CalculateControl()
    {
        control = poppedBalloonsCount / (totalBalloonsCount);
    }

    private void HitOrMissCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Background"))
                {
                    missClick += 1;
                }
            }
        }
    }

    public void GainPoint()
    {
        points += 1;
        balloonUiManager.UpdateUI();
    }
}
