using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        Ray lastRay;
        Player player;
        AudioSource  []audioSource2;
        

        private void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GetComponent<Player>();
            audioSource2 = GetComponents<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
            CheckHp();
        }


        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            if (!audioSource2[1].isPlaying)
            {
              audioSource2[1].Play();
            }
            MoveTo(destination);
        }


        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
            //if (target == null)
            //{
            //    audioSource2[1].Stop();
            //} 
        }


        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
        private void CheckHp()
        {
            if (player.healthAsPercentage <= 0)
            {
                Destroy(this);
            }
            
        }

        
    }
}
