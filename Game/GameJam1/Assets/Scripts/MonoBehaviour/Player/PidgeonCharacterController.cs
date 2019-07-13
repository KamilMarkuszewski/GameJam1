using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviour.Player
{
    public class PidgeonCharacterController : UnityEngine.MonoBehaviour
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

            AdjustCam();
            AdjustSprite();
        }

        private void AdjustCam()
        {
            Camera.main.orthographicSize = 3 + Mathf.Pow((transform.position.y / 15), 2.5f);
        }

        private void AdjustSprite()
        {
            var sr = GetComponentInChildren<SpriteRenderer>();
            sr.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f) * Mathf.Pow(2- ((30 - transform.position.y) / 30), 2.0f);
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
