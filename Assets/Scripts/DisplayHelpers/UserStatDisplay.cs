using Models;
using UnityEngine;
using UnityEngine.UI;

public class UserStatDisplay : MonoBehaviour
{
   private UserStat userStat;
   [SerializeField] private Text statName;
   [SerializeField] private GameObject streakObject;
   [SerializeField] private Text streakText;
   [SerializeField] private Text statCount;


   public void SetUpDisplay(UserStat stat)
   {
      userStat = stat;
      userStat.UpdateStatDisplay += SetUpStatCount;
      SetUpStatName();
      SetUpStreak();
      SetUpStatCount();
   }

   private void SetUpStatName()
   {
      statName.text = userStat.stat.name;
   }

   private void SetUpStreak()
   {
      streakObject.SetActive(false);
      if (userStat.streakCount <= 0) return;
      streakText.text = "" + userStat.streakCount;
      streakObject.SetActive(true);
   }

   private void SetUpStatCount()
   {
      statCount.text = "" + userStat.count;
   }

}
