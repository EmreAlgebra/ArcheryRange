using System.Collections;
using System.Collections.Generic;
using UdemyProje1.UIs;
using UnityEngine;

namespace UdemyProje1.UIs
{
    public class MenuCanvas : MonoBehaviour
    {

        [SerializeField]
        MenuPanel menuPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChangedForCanvas += HandleSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChangedForCanvas -= HandleSceneChanged;
        }

        private void HandleSceneChanged(bool isActive)
        {
            if (isActive == menuPanel.gameObject.activeSelf) return;

            menuPanel.gameObject.SetActive(isActive);
        }


        //public void ExitButtonClick()
        //{
        //    GameManager.Instance.ExitGame();
        //}
        //public void StartButtonClick()
        //{
        //    //GameManager.Instance.StartGame();

        //}
    }

}
