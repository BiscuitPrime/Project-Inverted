using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inverted.Achievements
{
    [CreateAssetMenu(fileName ="Achivement",menuName ="ScriptableObjects/Achievement")]
    public class AchievementRessource : ScriptableObject
    {
        [field:SerializeField] public int AchievementID { get; private set; }
        [field: SerializeField, InspectorName("Achievement Icon")] public Sprite AchievementIcon { get; private set; }
        [field: SerializeField, InspectorName("Achievement Title")] public string AchievementTitle { get; private set; }
        [field: SerializeField, TextArea(3,10),InspectorName("Achievement Description")] public string AchievementDescription { get; private set; }
        [field: SerializeField, TextArea(3, 10), InspectorName("Achievement Flavour")] public string AchievementFlavour { get; private set; }
    }
}
