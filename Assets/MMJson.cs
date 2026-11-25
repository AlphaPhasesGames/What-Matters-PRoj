using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;
namespace Alpha.Phases.What.Matters
{

    public class MMJson : MonoBehaviour
    {
        public TextMeshProUGUI stage1Text1;
        public TextMeshProUGUI stage1Text2;
        public TextMeshProUGUI stage1Text3;


        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;


            stage1Text1.text = defs["newGame"];
            stage1Text2.text = defs["continue"];
            stage1Text3.text = defs["autoTTS"];

        }
    }

}
