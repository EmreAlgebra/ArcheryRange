using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Controllers;
using UnityEngine;

namespace UdemyProje1.Spawners
{
    
    public class ArrowSpawner : MonoBehaviour
    {
        [SerializeField] ArrowController arrow;

        public void Spawn()
        {
            Instantiate(arrow, this.transform);
        }
    }

}

