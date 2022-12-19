using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Combats;
using UnityEngine;


namespace UdemyProje1.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        //[SerializeField] GameObject gamePlayObject;
        [SerializeField] GameObject gameOverPanel;


        //private void OnEnable()
        //{
        //    GameManager.Instance.OnSceneChangedForCanvas += HandleSceneChanged;
        //}



        //private void OnDisable()
        //{
        //    GameManager.Instance.OnSceneChangedForCanvas -= HandleSceneChanged;
        //}
        //private void HandleSceneChanged(bool isActive)
        //{
        //    if (!isActive == gamePlayObject.activeSelf) return;
        //    gamePlayObject.SetActive(!isActive);
        //}

        //public void ShowGameOverPanel()
        //{
        //    gameOverPanel.gameObject.SetActive(true);
        //}


        private void Awake()
        {
            gameOverPanel = transform.GetChild(3).gameObject;
            Time.timeScale = 1f;
        }

        private void Start()
        {
            Death _death = FindObjectOfType<Death>();
            _death.OnDeath += HandleOnDeath;
        }
        private void HandleOnDeath()
        {
            gameOverPanel.SetActive(true);
        }

    }
}

