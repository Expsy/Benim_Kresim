using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text KidName;


    public static UIManager uiManager;

    private void Awake()
    {
        if (uiManager != null)
        {
            Destroy(this);
        }
        else
        {
            uiManager = this;;
        }
        
        DontDestroyOnLoad(this);
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;   
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TMP_Text>();
        UpdateUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        coinText.text = ProfileManager.profileManager.coin.ToString();
        KidName.text = KidManager.kidManager.currentKid.name;
        
    }
}
