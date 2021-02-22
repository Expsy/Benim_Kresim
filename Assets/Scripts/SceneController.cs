using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

        public static SceneController sceneController;
        public Image fadeImage;

        private void Awake()
        {
                if (sceneController != null)
                {
                        Destroy(gameObject);
                }
                else
                {
                        sceneController = this;
                }
                
                
                
                FindFadeImage();
        }
        
        
        
        void Start()
        {
                fadeImage.canvasRenderer.SetAlpha(1f);
        
                FadeIn();
                
        
        }

        private void OnEnable()
        {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                SceneManager.sceneLoaded += OnSceneLoaded;   
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
                FindFadeImage();
                FadeIn();
        }

        public void GoNextScene()
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Exit()
        {
                Application.Quit();
        }

        public void GoTargetScene(int levelIndex)
        {
                SceneManager.LoadScene(levelIndex);   
        }

        public void GoNextSceneWithDelay(float delayInSecond)
        {
                FadeOut();
                Invoke("GoNextScene", delayInSecond);
                FindFadeImage();
        }
        
        // Update is called once per frame
        public void FadeOut()
        {

                fadeImage.CrossFadeAlpha(1,1,false);
        }

        public void FadeIn()
        {
                fadeImage.CrossFadeAlpha(0,1,false);
        }

        public void FindFadeImage()
        {
                fadeImage = GameObject.FindWithTag("FadeImage").GetComponent<Image>();
        }
}
