using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{


public class TargetObject : MonoBehaviour
{
        public bool reached=false;
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destructable dest = other.transform.root.GetComponent<Destructable>();

            if (dest != null && dest.TeamId == 2)
            {
                reached = true;
                


            }

            Debug.Log("reached" + reached);
        }

       

    }
}
