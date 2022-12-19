using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Enums;
using UnityEngine;


namespace UdemyProje1.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 2.5f;
        [SerializeField] DirectionEnum direction;

        Rigidbody2D _rigidbody2D;

        public float MoveSpeed 
        {
            get
            {
                return moveSpeed;
            }
            set
            {
                moveSpeed = value;
            }
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        
        private void OnEnable()
        {
            _rigidbody2D.velocity = SelectedNewDirection() * moveSpeed;
        }

        private Vector2 SelectedNewDirection()
        {
            Vector2 selectedDirection = new Vector2();
            if (direction == DirectionEnum.Left)
            {
                selectedDirection = Vector2.left;
            }
            else if (direction == DirectionEnum.Right)
            {
                selectedDirection = Vector2.right;
            }
            return selectedDirection;
        }
    }
}

