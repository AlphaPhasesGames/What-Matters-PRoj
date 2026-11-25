using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;
namespace Alpha.Phases.What.Matters
{
    public class Stage1LangMan : MonoBehaviour
    {

        public TextMeshProUGUI stage1Text1;
        public TextMeshProUGUI stage1Text2;
        public TextMeshProUGUI stage1Text3;
        public TextMeshProUGUI stage1Text4;
        public TextMeshProUGUI stage1Text5;
        public TextMeshProUGUI stage1Text6;
        public TextMeshProUGUI stage1Text7;
        public TextMeshProUGUI stage1Text8;
        public TextMeshProUGUI stage1Text9;
        public TextMeshProUGUI stage1Text10;
        public TextMeshProUGUI stage1Text11;
        public TextMeshProUGUI stage1Text12;
        public TextMeshProUGUI stage1Text13;
        public TextMeshProUGUI stage1Text14;
        public TextMeshProUGUI stage1Text15;
        public TextMeshProUGUI stage1Text16;
        public TextMeshProUGUI stage1Text17;
        public TextMeshProUGUI stage1Text18;
        public TextMeshProUGUI stage1Text19;
        public TextMeshProUGUI stage1Text20;
        public TextMeshProUGUI stage1Text21;
        public TextMeshProUGUI stage1Text22;
        public TextMeshProUGUI stage1Text23;


        public TextMeshProUGUI journalPage1;
        public TextMeshProUGUI journalPage2;

        public TextMeshProUGUI task1;
        public TextMeshProUGUI task2;
        public TextMeshProUGUI task3;



        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;


            stage1Text1.text = defs["stage1Text1"];
            stage1Text2.text = defs["stage1Text2"];
            stage1Text3.text = defs["stage1Text3"];
            stage1Text4.text = defs["stage1Text4"];
            stage1Text5.text = defs["stage1Text5"];
            stage1Text6.text = defs["stage1Text6"];
            stage1Text7.text = defs["stage1Text7"];
            stage1Text8.text = defs["stage1Text8"];
            stage1Text9.text = defs["stage1Text9"];
            stage1Text10.text = defs["stage1Text10"];
            stage1Text11.text = defs["stage1Text11"];
            stage1Text12.text = defs["stage1Text12"];
            stage1Text13.text = defs["stage1Text13"];
            stage1Text14.text = defs["stage1Text14"];
            stage1Text15.text = defs["stage1Text15"];
            stage1Text16.text = defs["stage1Text16"];
            stage1Text17.text = defs["stage1Text17"];
            stage1Text18.text = defs["stage1Text18"];
            stage1Text19.text = defs["stage1Text19"];
            stage1Text20.text = defs["stage1Text20"];
            stage1Text21.text = defs["stage1Text21"];
            stage1Text22.text = defs["stage1Text22"];
            stage1Text23.text = defs["stage1Text23"];


            journalPage1.text = defs["stage1Journal"];
            //journalPage2.text = defs["stage2Journal2"];

            task1.text = defs["stage1Task1"];
            task2.text = defs["stage1Task2"];
            task3.text = defs["stage1Task3"];

        }

    }
}
