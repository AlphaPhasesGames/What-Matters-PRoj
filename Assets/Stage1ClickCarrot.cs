using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Alpha.Phases.What.Matters
{
    public class Stage1ClickCarrot : MonoBehaviour
    {
        [SerializeField] private UnityEvent onClicked = new UnityEvent();
        public int arrayposition;
        public Stage1TextManager textman;
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            textman.ResetBools();
            textman.positionChanged = true;
            textman.arrayPos = arrayposition;
            onClicked.Invoke();
        }
    }
}
