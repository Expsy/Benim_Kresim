using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Stat : MonoBehaviour
{
        private RectTransform myGraph;
        private TMP_Text myPercent;
        public float tweenDuration = 2;
        public int percentage;

        private void Start()
        {
                myGraph = transform.GetChild(1).GetComponent<RectTransform>();
                myPercent = transform.GetChild(2).GetComponent<TMP_Text>();


        }

        public void StartTweens(float value)
        {
                TweenGraph(value);
                TweenPercent(value);  
                
                Debug.Log(myGraph);
                Debug.Log(myPercent);
                Debug.Log(value);


        }

        private void Update()
        {
                myPercent.text = $"%{percentage}";
        }

        public void TweenGraph(float value)
        {
                
                // myGraph.DOScaleY(value * 10, tweenDuration);
                myGraph.DOScaleY( value * 10, tweenDuration);
        }

        public void TweenPercent(float value)
        {
                int round = Mathf.RoundToInt(value * 100);
                DOTween.To(() => percentage, x => percentage = x, round, tweenDuration);
        }
}
