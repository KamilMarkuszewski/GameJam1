using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.MonoBehaviour
{
    public class DestroyAfterSec : UnityEngine.MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Invoke("Die", 10.0f);
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
