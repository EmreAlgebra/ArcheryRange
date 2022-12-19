using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.Abstracts.Controllers
{
    public abstract class LifeCycleController : MonoBehaviour
    {
        [SerializeField] float maxLifeTime = 5f;

        protected float _currentTime;

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > maxLifeTime)
            {

                #region değişiklik burada olacaktır. KillGameObject() yerine Destroy kullanılacak
                //KillGameObject();
                Destroy(this.gameObject);
                #endregion
            }        
        }

        //Aşağıdaki kod bloğu kaldırılacak
        //public abstract void KillGameObject();
    }
}

