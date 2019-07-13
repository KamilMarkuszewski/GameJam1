using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviour.Player
{
    public class PidgeonShootingController : UnityEngine.MonoBehaviour
    {
        public ObjectPool<BulletScript> BulletsObjectPool;
        public Transform BulletPrefab;
        public Transform BulletParent;

        public Transform PidgeonSprite;

        private float _lastShootTime;

        private PidgeonCharacterController _characterController;
        public PidgeonCharacterController CharacterController
        {
            get { return _characterController ?? (_characterController = FindObjectOfType<PidgeonCharacterController>()); }
        }


        private BulletScript ObjectGenerator()
        {
            var bullet = Instantiate(BulletPrefab.gameObject, BulletParent);
            var scr = bullet.GetComponent<BulletScript>();
            scr.Rigidbody.isKinematic = true;
            return scr;
        }

        void Awake()
        {
            BulletsObjectPool = new ObjectPool<BulletScript>(ObjectGenerator);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Shoot"))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if (Time.time > _lastShootTime + 1.0f)
            {
                _lastShootTime = Time.time;
                var bullet = BulletsObjectPool.GetObject();
                bullet.Rigidbody.isKinematic = false;
                bullet.transform.position = PidgeonSprite.transform.position;
                bullet.Rigidbody.AddForce(transform.forward * 95 * CharacterController.Speed * 4);
            }
        }
    }
}
