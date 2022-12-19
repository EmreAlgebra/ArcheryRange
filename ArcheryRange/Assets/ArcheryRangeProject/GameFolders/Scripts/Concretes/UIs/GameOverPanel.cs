using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            //GameManager.Instance.StartGame();
            //GameManager.Instance.LoadScene();
            GameManager.Instance.RestartGame();
            this.gameObject.SetActive(false);
        }

        public void NoButtonClickk()
        {
            //GameManager.Instance.ReturnMenu();
            //GameManager.Instance.LoadMenuAndUi(1f);
            Destroy(GameManager.Instance.transform.gameObject);
        }

    }
}

