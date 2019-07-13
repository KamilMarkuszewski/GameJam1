using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.MonoBehaviour.Player;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviour
{
    public class BulletScript : UnityEngine.MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public Rigidbody Rigidbody
        {
            get { return _rigidbody ?? (_rigidbody = GetComponent<Rigidbody>()); }
        }

        private PidgeonShootingController _shootingController;
        public PidgeonShootingController ShootingController
        {
            get { return _shootingController ?? (_shootingController = FindObjectOfType<PidgeonShootingController>()); }
        }





        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision col)
        {
            if (col.transform.tag == "Bottom")
            {
                Rigidbody.isKinematic = true;
                transform.position = new Vector3(1000, 1000, 100);
                ShootingController.BulletsObjectPool.PutObject(this);
            }


        }


    }
}
