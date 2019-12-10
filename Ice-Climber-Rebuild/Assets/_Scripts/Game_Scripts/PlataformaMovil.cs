using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Game_Scripts
{
    
    public class PlataformaMovil : MonoBehaviour
    {
        public Transform target;
        public float speed;
        SpriteRenderer SPbird;
        private Vector3 start, end;

        // Start is called before the first frame update
        void Start()
        {
            SPbird = GetComponent<SpriteRenderer>();
            if (target != null)
            {
                target.parent = null;
                start = transform.position;
                end = target.position;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (target != null)
            {
                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
            }

            if(transform.position == target.position)
            {
                target.position = (target.position == start) ? end : start;
                if (this.CompareTag("Enemy"))
                {
                    SPbird.flipX = !SPbird.flipX;
                }
            }
        }
    }
}