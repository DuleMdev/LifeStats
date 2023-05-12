using Models;
using UnityEngine;
using UnityEngine.UI;

namespace DisplayHelpers
{
    public class StatDisplay: MonoBehaviour
    {
        private Stat stat;
        [SerializeField] private Text statName;
        [SerializeField] private Text selectionText;
        [SerializeField] private Button selectionButton;
        
        public void SetUpDisplay(Stat s,bool t)
        {
            stat = s;
            SetUpStatName();
            SetUpSelection(t);
        }
        private void SetUpStatName()
        {
            statName.text = stat.name;
        }

        private void SetUpSelection(bool t)
        {
            selectionText.text = t ? "Added" : "Click to add";
            selectionButton.interactable = t;
        }

        public void StatSelected()
        {
            
        }
        
    }
}