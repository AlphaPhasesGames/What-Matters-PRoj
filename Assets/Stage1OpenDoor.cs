using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.What.Matters
{
    public class Stage1OpenDoor : MonoBehaviour
    {

        public Animator door;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                door.SetBool("open", true);
            }
        }
    }
}
