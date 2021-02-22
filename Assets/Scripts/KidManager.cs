using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidManager : MonoBehaviour
{
        public static KidManager kidManager;



        public List<KidObject> kidList;
        public KidObject currentKid;
        private int kidOrder = 0;

        private void Awake()
        {
                if(kidManager != null)
                        GameObject.Destroy(kidManager);
                else
                        kidManager = this;
         
                DontDestroyOnLoad(this);
        }

        private void Update()
        {
                
        }

        public void PutKidsInOrder()
        {
                kidOrder = 0;
                currentKid = kidList[kidOrder];
        }

        public void NextKid()
        {
                if (!IsItLastKid())
                {
                        kidOrder += 1;
                        currentKid = kidList[kidOrder];
                        UIManager.uiManager.UpdateUI();;
                }
                else if (IsItLastKid())
                {
                        SceneController.sceneController.GoNextSceneWithDelay(1);
                }
        }
        
        public void CheckIfCleaned()
        {
                if (currentKid.myKid.dirtyNailCount <= 0)
                {
                        currentKid.myKid.dirty = false;
                }
        }

        public bool IsItLastKid()
        {
                if (kidOrder == kidList.Count - 1)
                {
                        return true;
                }
                else
                {
                        return false;
                }
        }
}

