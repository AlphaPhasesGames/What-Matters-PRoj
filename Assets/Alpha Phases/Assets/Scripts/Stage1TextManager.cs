using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;
namespace Alpha.Phases.What.Matters
{
    public class Stage1TextManager : MonoBehaviour
    {
        public SimpleRobotMovement playerCont;
        public Stage1CameraPositionManager camMan;
        public GameObject playerModel;
       // public JournalOpenButton journalOpen;
        public bool hasScrolled;
        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 0;
        public GameObject taskBar;
        public GameObject task1Text;
       // public GameObject task2Text;
       // public GameObject task3Text;
        public bool positionChanged;
        public Button journalButton;
        public bool runThrice;

        public Camera playerCam;
        public Camera objectCam;

        public Animator tankAnim;

        public GameObject[] modelArray;
        public GameObject textPanal;

        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;

        public bool submitOnce;
        public bool submitTwice;
        public bool submitThrice;
        public bool submitFourth;
        public Button forwardButton;
        public Button backwardsButton;

        public Button[] textButtons;
        public bool[] textBools;

        public Button crossButton1;
        public Button closeTableView;
       // public GameObject depotArrow;
        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);
            journalButton.onClick.AddListener(SpeakJournal1);
            crossButton1.onClick.AddListener(CrossButton);
            closeTableView.onClick.AddListener(CloseTableVeiw);

            for (int i = 0; i < textButtons.Length; i++)
            {
                int index = i + 1;  // Adjust index to match textButton number
                textButtons[i].onClick.AddListener(() => IntroTTSSpeak(index));
            }
            if (MainGameManager.Instance.currentTask < 1)
            {
                StartCoroutine(StartStage1());
            }


        }

        // Start is called before the first frame update
        void Start()
        {
            maxLengthArray = modelArray.Length;
            textBools = new bool[maxLengthArray];
        }

        void Update()
        {


            // Only process if the position has changed
            if (positionChanged)
            {
                positionChanged = false;

                // Deactivate all text objects, activate only the current one
                for (int i = 0; i < modelArray.Length; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                }

                if (MainGameManager.Instance.autoTTS)
                {
                    IntroTTSSpeak(arrayPos + 1);
                }

                // Handle the current array position if not yet processed
                if (!textBools[arrayPos])
                {
                    HandleArrayPosActions();
                    textBools[arrayPos] = true;
                }
            }
        }

        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    if (!submitOnce)
                    {
                        LOLSDK.Instance.SubmitProgress(0, 0, 100);
                        submitOnce = true;
                    }
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());
                   
                    Debug.Log("Array pos 0 runs");
                    break;

                case 1:
                   
                    
                    break;
                case 2:
                    taskBar.gameObject.SetActive(true);
                    task1Text.gameObject.SetActive(true);
                    StartCoroutine(EnableCross());
                    break;
                case 3:
                    textPanal.gameObject.SetActive(true);
                    playerCont.moveSpeed = 0;
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());
                    break;                   
                case 4:
                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 5:
                  
                   
                    break;
                case 6:
                    StartCoroutine(EnableCross());
                    break;
                case 7: // lamp table look
                    playerModel.gameObject.SetActive(false);
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    closeTableView.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    break;
                    
               case 8: // Look at lamp
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());
                    break;

               case 9: // Properties Panal
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(true);
                   break;
               case 10: // Lamp Correct
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(true);
                    StartCoroutine(EnableCross());
                    break;
               case 11: // Incorrect, come back later.
                    textPanal.gameObject.SetActive(true);
                   
                    backwardsButton.gameObject.SetActive(false);
                  
                    break;
               case 12: // Look at shadow Table
                    playerModel.gameObject.SetActive(false);
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    closeTableView.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    break;
               case 13: // Look atshadow props
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());

                    break;
               case 14: // shadow statements
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                   
                    break;
               case 15:// correct shadow
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    break;
                case 16:// incorrect shadow           
                    playerModel.gameObject.SetActive(false);
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    closeTableView.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    break;
                case 17:// look at shadow itself
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(true);
                    StartCoroutine(DelayTextButton());
                    break;
                case 18:// shadow Properties
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(EnableCross());
                    break;
                case 19:// Look at sugar table
                    playerModel.gameObject.SetActive(false);
                    playerCont.moveSpeed = 0;
                    textPanal.gameObject.SetActive(true);
                    closeTableView.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    break;
                case 20:// Look at sugar
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(DelayTextButton());
                    break;                  
                case 21:// Sugar properties
                    textPanal.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    StartCoroutine(EnableCross());
                    break;
                case 22:
                    camMan.GoToTank();
                    tankAnim.SetBool("floor", true);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(EnableCross());
                    break;
                case 23:
                    textPanal.gameObject.SetActive(false);
                    break;                    
                

            }
        }

        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage1Text{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"stage1Text{textIndex} Button is pressed");
        }


        public void ProgressTextForward()
        {
            if (arrayPos < maxLengthArray - 1)
            {
                arrayPos++;
                positionChanged = true;
                hasScrolled = false;
                forwardButton.gameObject.SetActive(false);

                // Only run DelayTextButton if the next arrayPos is not 2
                if (arrayPos != 2 & arrayPos != 6 & arrayPos != 7 & arrayPos != 9 & arrayPos != 10 & arrayPos != 11 & arrayPos != 12 & arrayPos != 13 & arrayPos != 15 & arrayPos != 17 & arrayPos != 18)
                {
                    StartCoroutine(DelayTextButton());
                }
            }
        }


        public void ProgressTextBack()
        {

            if (arrayPos > minLengthArray)
            {
                arrayPos--;
                positionChanged = true; // Mark position as changed
                hasScrolled = false;
                Array.Fill(textBools, false);
            }
        }

        public void ResetPositionFlags()
        {
            Array.Fill(textBools, false); // Reset all boolean flags for text
            positionChanged = true;       // Mark position as changed for Update() processing
        }


        private void SpeakText(string textKey)
        {
            LOLSDK.Instance.SpeakText(textKey);
        }


        public void SpeakJournal1()
        {
            LOLSDK.Instance.SpeakText("stage1Journal");
        }
        public void DisableCross()
        {

            crossButton1.gameObject.SetActive(false);
        }


        public void SpeakJournal4RegMeta()
        {
            LOLSDK.Instance.SpeakText("concept4RegionalMeta");
        }

        public void ResetBools()
        {
            Array.Fill(textBools, false);
        }

        public IEnumerator DelayTextButton()
        {

            yield return new WaitForSeconds(1f);
          
            forwardButton.gameObject.SetActive(true);

            Debug.Log("This coRoutine Runs");

        }


        public IEnumerator MoveToBlankInvislbePanalUnit17()
        {
            yield return new WaitForSeconds(4);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 22;
            //playerCont.moveSpeed = 5;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanalUnit172()
        {
            yield return new WaitForSeconds(7);
            //playerMoveScript.enabled = true;
            textPanal.gameObject.SetActive(false);
            arrayPos = 44;
            playerCont.moveSpeed = 8;
            Debug.Log("This start coRoutine Runs");

        }


        public IEnumerator StartStage1()
        {
            yield return new WaitForSeconds(2);

            textPanal.gameObject.SetActive(true);

            arrayPos = 0;
            positionChanged = true;      // <-- ensure Update processes arrayPos 0
                                         // textBools[0] = true;      // <-- remove this so case 0 will run
            Debug.Log("This start coRoutine Runs");
        }

        public IEnumerator EnableCross()
        {
            yield return new WaitForSeconds(1f);
            crossButton1.gameObject.SetActive(true);
            Debug.Log("This start coRoutine Runs");
        }


        public void CrossButton()
        {
            textPanal.gameObject.SetActive(false);

            positionChanged = false;
            arrayPos = 23;

            playerCont.moveSpeed = 8;
            crossButton1.gameObject.SetActive(false);
        }
        
        public void CloseTableVeiw()
        {
           
            objectCam.gameObject.SetActive(false);
            playerCam.gameObject.SetActive(true);
            playerModel.gameObject.SetActive(true);
            playerCont.moveSpeed = 8;
            positionChanged = true;
            arrayPos = 23;
            //textPanal.gameObject.SetActive(false);

        }

        public IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("Stage 2 newspapers");
        }

        public void GoToPos10() //  this function fires to move the text box to posiiton 10 or 9 in the array.
        {
            positionChanged = true;
            arrayPos = 9;
        }

        
    }
}

