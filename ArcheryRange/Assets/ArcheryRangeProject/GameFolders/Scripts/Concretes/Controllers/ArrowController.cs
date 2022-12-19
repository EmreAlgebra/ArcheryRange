using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProje1.Controllers
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] float maxLifeTime = 2f;

        float _currentTime;

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > maxLifeTime)
            {
                Destroy(this.gameObject);
            }
        }
        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameManager.Instance.RestartGame();
        }
        */
    }
}

