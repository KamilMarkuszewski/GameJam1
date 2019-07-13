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
        private ObjectPool<Transform> _bulletsObjectPool;
        public Transform BulletPrefab;
        public Transform BulletParent;


        private Transform ObjectGenerator()
        {
            var bullet = Instantiate(BulletPrefab.gameObject, BulletParent);

            return bullet.transform;
        }

        void Awake()
        {
            _bulletsObjectPool = new ObjectPool<Transform>(ObjectGenerator);
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
                var bullet = _bulletsObjectPool.GetObject();
                bullet.transform.position = gameObject.transform.position;
            }
        }
    }
}
