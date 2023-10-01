using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Characters.Enemy.Scripts
{
    public class AnimalMovementController : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");

        public LayerMask whatIsFood;

        //States
        public float sightRange;
        public bool foodInRange;

        public Transform _food;

        private bool isQuitting;

        private void Awake()
        {
            //  _player = GameObject.FindWithTag("Player").transform;
        }


        private void Start()
        {
            CheckState();
        }

        private void Update()
        {
            CheckState();
        }

        private void OnDestroy()
        {
            if (isQuitting)
            {
                return;
            }
        }

        private void OnApplicationQuit()
        {
            isQuitting = true;
        }


        //debugging
        private void OnDrawGizmosSelected()
        {
            var position = transform.position;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(position, sightRange);
        } // ReSharper disable Unity.PerformanceAnalysis
        
        public void CheckState()
        {
            //  if (_food.CompareTag("Meat"))
                {
                    EatFood();
                }
        }

        


        private void EatFood()
        {
            //Make sure enemy doesn't move
           // _agent.SetDestination(transform.position);


          // var lookAtTarget =
          //      new Vector3(_food.transform.position.x, transform.position.y, _food.transform.position.z);
         //   transform.LookAt(lookAtTarget);
            
            // Move our position a step closer to the target.
            var step =  0.5f * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _food.position, step);
           // var destination = 2*Time.deltaTime;
           // transform.Translate(_food.position*destination);
        }
    }
}