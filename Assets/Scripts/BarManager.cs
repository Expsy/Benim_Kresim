using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    
    public static BarManager barManager;
    
    public GameObject foam;
    public Image bar;
    private float time;
    private float oneUnitFoam = 86.4f;
    private float oneUnitBar = 0.20f;
    private int totalBarUnits = 5;
    private int currentBarFillAmount = 0;
    Vector2 defaultResetPosition = new Vector2(-216, 0);
    private RectTransform foamTransform;

    private void Awake()
    {
        if(barManager != null)
            GameObject.Destroy(this);
        else
            barManager = this;
         
        DontDestroyOnLoad(this);
        
        foamTransform = foam.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BarProgressCoroutine(1));
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(BarResetCoroutine());
        }
    }

    IEnumerator BarProgressCoroutine(int barMultiplier)
    {
        float initialBarFillAmount = bar.fillAmount;
        time = 0;
        float duration = 0.5f;
        Vector2 initialPos = foamTransform.localPosition;
        while (time <= duration)
        {
            FillFoam(foamTransform, initialPos, duration, barMultiplier);
            FillBar(barMultiplier, initialBarFillAmount, duration);
            time += Time.deltaTime;
            yield return null;
        }
        FixFoam(barMultiplier, foamTransform, initialPos);

        currentBarFillAmount += barMultiplier;

        CheckIfBarIsFilled();

    }

    private void FixFoam(int barMultiplier, RectTransform foamTransform, Vector2 initialPos)
    {
        foamTransform.localPosition = initialPos + new Vector2(oneUnitFoam * barMultiplier, 0f);
    }

    private void FillBar(int barMultiplier, float initialBarFillAmount, float duration)
    {
        bar.fillAmount = Mathf.Lerp(initialBarFillAmount, initialBarFillAmount + oneUnitBar * barMultiplier,
            time / duration);

    }

    private void FillFoam(RectTransform foamTransform, Vector2 initialPos, float duration, int barMultiplier)
    {
        foamTransform.localPosition = Vector2.Lerp(initialPos, initialPos + new Vector2(oneUnitFoam * barMultiplier, 0f), time / duration);
    }

    public void BeginBarProgressCoroutine(int barMultiplier)
    {
        StartCoroutine(BarProgressCoroutine(barMultiplier));
    }

    IEnumerator BarResetCoroutine()
    {
        float initialBarFillAmount = bar.fillAmount;
        time = 0;
        float duration = 1;
        Vector2 initialPos = foamTransform.localPosition;
        while (time <= duration)
        {
            bar.fillAmount = Mathf.Lerp(initialBarFillAmount, 0,time / duration);
            foamTransform.localPosition = Vector2.Lerp(initialPos, defaultResetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        foamTransform.localPosition = defaultResetPosition;

        currentBarFillAmount = 0;
    }

    void CheckIfBarIsFilled()
    {
        if (currentBarFillAmount == totalBarUnits)
        {
            ProfileManager.profileManager.coin++;
            UIManager.uiManager.UpdateUI();
            StartCoroutine(BarResetCoroutine());
        }
    }
}
