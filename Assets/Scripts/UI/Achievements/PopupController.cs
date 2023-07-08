using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Inverted.Achievements
{
    public class PopupController : MonoBehaviour
    {
        [SerializeField] private Image _achIcon;
        [SerializeField] private TextMeshProUGUI _achTitle;
        [SerializeField] private TextMeshProUGUI _achFlavour;

        public void TriggerPopup(AchievementRessource achievementRessource)
        {
            Debug.Log("[AchivementPopup] : Triggering popup called");
            Assert.IsNotNull(achievementRessource);
            GetComponent<Animator>().enabled = true;
            _achIcon.sprite = achievementRessource.AchievementIcon;
            _achTitle.text = achievementRessource.AchievementTitle;
            _achFlavour.text = achievementRessource.AchievementFlavour;
        }

        public void TriggerAchievementDisplay(AchievementRessource achievementRessource)
        {
            Assert.IsNotNull(achievementRessource);
            _achIcon.sprite = achievementRessource.AchievementIcon;
            _achTitle.text = achievementRessource.AchievementTitle;
            _achFlavour.text = achievementRessource.AchievementFlavour;
        }
    }
}
