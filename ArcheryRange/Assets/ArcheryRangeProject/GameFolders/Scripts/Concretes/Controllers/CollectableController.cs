using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Abstracts.Controllers;
using UnityEngine;

namespace UdemyProje1.Controllers
{
    public class CollectableController : LifeCycleController
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _animator.SetTrigger("isCreated");
        }
    }

}
