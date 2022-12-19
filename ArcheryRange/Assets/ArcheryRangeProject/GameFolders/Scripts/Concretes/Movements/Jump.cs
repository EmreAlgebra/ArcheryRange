using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.Movements
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce = 300f;

        void Awake()
        {

        }
        void Update()
        {

        }

        public void JumpAction(Rigidbody2D rigidbody2D)
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}

