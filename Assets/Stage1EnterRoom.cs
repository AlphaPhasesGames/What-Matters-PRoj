using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alpha.Phases.What.Matters
{
    public class Stage1EnterRoom : MonoBehaviour
    {
        public bool runOnce;
        public BoxCollider triggerBox;
        public Stage1TextManager textMan;


        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                if (!runOnce)
                {
                    textMan.positionChanged = true;
                    textMan.arrayPos = 3;
                    triggerBox.enabled = false;
                    runOnce = true;
                }
            }
        }
    }
}
