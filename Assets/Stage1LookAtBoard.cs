using UnityEngine;
using UnityEngine.Events;
namespace Alpha.Phases.What.Matters
{
    public class Stage1LookAtBoard : MonoBehaviour
    {
        [SerializeField] private UnityEvent onPlayerEnter = new UnityEvent();
        public Stage1TextManager textMan;
        public int arrayPosition;
        public BoxCollider collider;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("This Runs");
                onPlayerEnter.Invoke();
                textMan.playerModel.gameObject.SetActive(false);
                collider.enabled = false;
                textMan.ResetBools();
                textMan.positionChanged = true;
                textMan.arrayPos = arrayPosition;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                
                textMan.playerModel.gameObject.SetActive(true);
                textMan.positionChanged = true;
                textMan.arrayPos = 23;
            }
        }
    }
}
