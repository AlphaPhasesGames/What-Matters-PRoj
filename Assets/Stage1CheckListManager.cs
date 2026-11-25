using UnityEngine;
using UnityEngine.UI;
namespace Alpha.Phases.What.Matters
{
    public class Stage1CheckListManager : MonoBehaviour
    {
        public Button carrotButt;
        public Button shadowButt;
        public Button waterButt;
        public Button sugarButt;
        public Button lightButt;
        public Button balloonButt;
        public Button paperButt;
        public Button confirm;
        public Button close;

        public GameObject tick1;
        public GameObject tick2;
        public GameObject tick3;
        public GameObject tick4;
        public GameObject tick5;
        public GameObject tick6;
        public GameObject tick7;

        public Stage1TextManager textMan;

        private void Awake()
        {
            carrotButt.onClick.AddListener(() => ToggleTick(tick1));
            shadowButt.onClick.AddListener(() => ToggleTick(tick2));
            waterButt.onClick.AddListener(() => ToggleTick(tick3));
            sugarButt.onClick.AddListener(() => ToggleTick(tick4));
            lightButt.onClick.AddListener(() => ToggleTick(tick5));
            balloonButt.onClick.AddListener(() => ToggleTick(tick6));
            paperButt.onClick.AddListener(() => ToggleTick(tick7));
            confirm.onClick.AddListener(CheckSelection);
            close.onClick.AddListener(CloseView);
        }

        private void ToggleTick(GameObject tick)
        {
            tick.SetActive(!tick.activeSelf);
        }

        private void CheckSelection()
        {
            bool correctSelection =
                tick1.activeSelf &&  // Carrot
                !tick2.activeSelf && // Shadow
                tick3.activeSelf &&  // Water
                tick4.activeSelf &&  // Sugar
                !tick5.activeSelf && // Light
                tick6.activeSelf &&  // Balloon
                tick7.activeSelf;    // Paper

            textMan.arrayPos = correctSelection ? 21 : 20;
            textMan.positionChanged = true;
        }

        public void CloseView()
        {
            textMan.CloseTableVeiw();
        }
    }
}