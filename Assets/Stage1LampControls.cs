using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;
namespace Alpha.Phases.What.Matters
{
    public class Stage1LampControls : MonoBehaviour
    {

        public Button onButton;
        public Button offButton;
        public GameObject lampLight;
        private void Awake()
        {
            onButton.onClick.AddListener(TurnOnButton);
            offButton.onClick.AddListener(TurnOffButton);
        }

        public void TurnOffButton()
        {
            onButton.gameObject.SetActive(true);
            offButton.gameObject.SetActive(false);
            lampLight.gameObject.SetActive(false);
        }

        public void TurnOnButton()
        {
            onButton.gameObject.SetActive(false);
            offButton.gameObject.SetActive(true);
            lampLight.gameObject.SetActive(true);
        }
    }      
}
