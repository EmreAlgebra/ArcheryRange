using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProje1.Combats
{

    public class Death : MonoBehaviour
    {
        [SerializeField] bool _isDeath;
        public bool IsDeath => _isDeath;

        public event System.Action OnDeath;



        //oyuncunun kontrolu yitirilmeli target footları çıktığı zaman
        //OnCollisionEnter2D metodu yerine target alandan dışarı çıktı mı metodu işleyecek oradan true dönerse oyun game over işletecek. 
        public void stopGame()
        {
            _isDeath = true;
            Time.timeScale = 0f;
            OnDeath?.Invoke();
            //zamanı durduruyoruz. Bıçak gibi keser durdurur zamanı
            //

        }
    }

}

