using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Alpha.Phases.What.Matters
{
    public class SetupStage1 : MonoBehaviour
    {

        public bool runonce;
        public bool runOnceTwice;
        public Stage1TextManager textMan;
        public GameObject taskBar;
        // public CameraMan camera;


        private void Awake()
        {
            if (!runonce)
            {
                MainGameManager.Instance.currentStagedqwb = 1;
                MainGameManager.Instance.SaveS1S1();
            

                if (MainGameManager.Instance.currentTask == 1)
                {

                    textMan.positionChanged = true;
                    textMan.arrayPos = 0;
                }

               /* if (MainGameManager.Instance.currentTask == 2)
                {
                    taskBar.gameObject.SetActive(true);
                    textMan.positionChanged = true;
                    textMan.arrayPos = 8;
                }*/

                runonce = true;
            }
        }
    }
}