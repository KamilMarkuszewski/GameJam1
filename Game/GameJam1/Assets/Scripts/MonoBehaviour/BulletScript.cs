using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
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

        public Sprite[] ShitSprites;

        public Transform ShitPrefab;

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
            ExecCollision(col.collider);
        }

        void OnTriggerEnter(Collider col)
        {
            ExecCollision(col);
        }

        private void ExecCollision(Collider col)
        {
            if (col.transform.tag == "Bottom")
            {
                Instantiate(ShitPrefab.gameObject, GetColPoint(col), Quaternion.identity);
                Rigidbody.isKinematic = true;
                transform.position = new Vector3(1000, 1000, 100);
                ShootingController.BulletsObjectPool.PutObject(this);
            }
            if (col.transform.tag == "Human")
            {
                Debug.Log("Trafiony");
                var shitObj = Instantiate(ShitPrefab.gameObject, GetColPoint(col), Quaternion.identity);
                shitObj.GetComponentInChildren<SpriteRenderer>().sprite = ShitSprites[UnityEngine.Random.Range(0, ShitSprites.Length - 1)];
            }
        }

        private Vector3 GetColPoint(Collider col)
        {
            var colPoint = col.ClosestPoint(transform.position);
            if (colPoint.y < 0.01f)
            {
                colPoint = new Vector3(colPoint.x, 0.01f, colPoint.z);
            }
            return colPoint;
        }
    }
}
