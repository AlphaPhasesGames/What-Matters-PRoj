using UnityEngine;
using UnityEngine.UI;

namespace Alpha.Phases.What.Matters
{
    public class Stage1LightManagment : MonoBehaviour
    {
        [System.Serializable]
        public class Statement
        {
            public Button button;
            public GameObject tick;
            public bool correctAnswer;
            public int selectionGroup;
        }

        [Header("Statements")]
        public Statement[] statements;

        [Header("Buttons")]
        public Button confirmAndClose;

        [Header("Dialogue")]
        public Stage1TextManager textMan;
      //  public int correctDialogue;
      //  public int incorrectDialogue;

        private void Awake()
        {
            foreach (Statement statement in statements)
            {
                statement.button.onClick.AddListener(
                    () => ToggleTick(statement));
            }

            // confirm.onClick.AddListener(CheckSelection);
            confirmAndClose.onClick.AddListener(CloseView);

            ResetSelection();
        }

        private void ToggleTick(Statement selected)
        {
            selected.tick.SetActive(!selected.tick.activeSelf);

            if (selected.tick.activeSelf)
            {
                foreach (Statement statement in statements)
                {
                    if (statement.selectionGroup != selected.selectionGroup)
                    {
                        statement.tick.SetActive(false);
                    }
                }
            }
        }
        public bool CheckSelection()
        {
            foreach (Statement statement in statements)
            {
                if (statement.tick.activeSelf != statement.correctAnswer)
                {
                    return false;
                }
            }

            return true;
        }
        public void ResetSelection()
        {
            foreach (Statement statement in statements)
            {
                statement.tick.SetActive(false);
            }
        }

        public void CloseView()
        {
            textMan.CloseTableVeiw();
        }
    }
}