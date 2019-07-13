using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterController : MonoBehaviour
    {

        public float DefaultSpeed = 0.02f;
        public float Speed;

        public float MinYPos = 3.1f;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CalcSpeed();

            Rotate();
            MoveForward();

            MoveUpDown();
        }

        private void MoveUpDown()
        {
            var y = Input.GetAxis("Vertical") / 20.0f;
            if (transform.position.y + y < 30)
            {
                if (transform.position.y + y > MinYPos)
                {
                    transform.Translate(0, y, 0);
                }
                else
                {
                    EnsureYPos();
                }
            }

            if (transform.position.y < MinYPos)
            {
                EnsureYPos();
            }
        }

        private void EnsureYPos()
        {
            transform.position = new Vector3(transform.position.x, MinYPos, transform.position.z);
        }

        private void Rotate()
        {
            var x = Input.GetAxis("Horizontal");
            transform.Rotate(0, x, 0);
        }

        private void MoveForward()
        {
            transform.Translate(new Vector3(0, 0, Speed));
        }

        private void CalcSpeed()
        {
            Speed = 0.01f + (transform.position.y - MinYPos) / 1000.0f * 2.0f;
        }
    }
}
