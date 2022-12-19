using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.Movements
{
    public class MotionsSet : MonoBehaviour
    {
        GameObject _obsticleSpawnerLeftTop, _obsticleSpawnerLeftMiddle, _obsticleSpawnerLeftBottom;
        GameObject _obsticleSpawnerRightTop, _obsticleSpawnerRightMiddle, _obsticleSpawnerRightBottom;

        private void Awake()
        {
            _obsticleSpawnerLeftTop = GameObject.FindWithTag("OBSLT");
            _obsticleSpawnerLeftMiddle = GameObject.FindWithTag("OBSLM");
            _obsticleSpawnerLeftBottom = GameObject.FindWithTag("OBSLB");

            _obsticleSpawnerRightTop = GameObject.FindWithTag("OBSRT");
            _obsticleSpawnerRightMiddle = GameObject.FindWithTag("OBSRM");
            _obsticleSpawnerRightBottom = GameObject.FindWithTag("OBSRB");
        }
        public void MotionOne()
        {

        }
    }
}

