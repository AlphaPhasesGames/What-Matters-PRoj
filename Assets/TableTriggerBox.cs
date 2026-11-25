using UnityEngine;
using UnityEngine.Events;
namespace Alpha.Phases.What.Matters
{
    public class TableTriggerBox : MonoBehaviour
    {
        [SerializeField] private UnityEvent onPlayerEnter = new UnityEvent();
        public Stage1TextManager textMan;
        public int arrayPosition;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("This Runs");
                onPlayerEnter.Invoke();
                textMan.ResetBools();
                textMan.positionChanged = true;
                textMan.arrayPos = arrayPosition;
            }
        }
    }
}