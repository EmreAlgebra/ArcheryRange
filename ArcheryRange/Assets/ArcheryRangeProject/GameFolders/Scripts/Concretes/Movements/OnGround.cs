using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Combats;
using UdemyProje1.Controllers;
using UdemyProje1.Helper;
using UnityEngine;

namespace UdemyProje1.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] bool isOnGround = false;
        [SerializeField] Transform[] translates;
        [SerializeField] float maxDistance = 1f;
        [SerializeField] LayerMask layerMask;
        
        public bool IsOnGround => isOnGround;

        byte _insideGround = 0;
        public byte InsideGround => _insideGround;

        BoxCollider2D _boxCollider2D;
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            foreach (Transform footTransform in translates)
            {

                CheckFootOnGround(footTransform); 

                if (isOnGround) {
                    _insideGround = 1;
                    break;
                }
            }
        }
        private void CheckFootOnGround(Transform footTransform)
        {
            
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance,layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

            if (InGameVariables._isBoxColliderEnabled)
            {
                if (hit.collider != null)
                {
                    isOnGround = true;
                    _boxCollider2D.enabled = true;
                }
                else
                {
                    isOnGround = false;
                    _boxCollider2D.enabled = false;
                    if (_insideGround == 1)
                    {
                        Death _death = FindObjectOfType<Death>();
                        _death.stopGame();
                    }
                }
            }
            
        }
    }

}
