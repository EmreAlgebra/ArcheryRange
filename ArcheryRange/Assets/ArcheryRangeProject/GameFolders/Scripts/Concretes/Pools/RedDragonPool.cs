using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Pools;
using UdemyProje1.Controllers;
using UnityEngine;


namespace UdemyProje1.Pools
{
    public class RedDragonPool : GenericPool<RedDragonController>
    {
        public static RedDragonPool Instance { get; private set; }

        public override void ResetAllObjects()
        {
            foreach (var child in transform.GetComponentsInChildren<RedDragonController>())
            {
                if (!child.gameObject.activeSelf) continue;
                //child.KillGameObject();
            }
        }

        protected override void SingletonObject()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}
