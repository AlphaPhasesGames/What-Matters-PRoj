using UnityEngine;
namespace Alpha.Phases.What.Matters
{
    public class Stage1CameraPositionManager : MonoBehaviour
    {
        public Transform labTable1;
        public Transform labTable2;
        public Transform labTable3;
        public Transform labTable4;
        public Transform labTable5;
       // public Transform checklostPos;
        public Transform tankCamPosition;

        public Camera tableCam;
        public Camera mainCam;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) GoToTable1();
            if (Input.GetKeyDown(KeyCode.Alpha2)) GoToTable2();
            if (Input.GetKeyDown(KeyCode.Alpha3)) GoToTable3();
            if (Input.GetKeyDown(KeyCode.Alpha4)) GoToTable4();
            if (Input.GetKeyDown(KeyCode.Alpha5)) GoToTable5();
        }

        public void GoToTable1() => MoveCamera(labTable1);
        public void GoToTable2() => MoveCamera(labTable2);
        public void GoToTable3() => MoveCamera(labTable3);
        public void GoToTable4() => MoveCamera(labTable4);

        public void GoToTable5() => MoveCamera(labTable5);

       // public void GoToCheckList() => MoveCamera(checklostPos);

        public void GoToTank() => MoveCamera(tankCamPosition);
        private void MoveCamera(Transform target)
        {
            tableCam.transform.SetPositionAndRotation(target.position, target.rotation);
            tableCam.gameObject.SetActive(true);
            mainCam.gameObject.SetActive(false);
        }
    }
}