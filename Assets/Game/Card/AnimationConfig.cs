using UnityEngine;

namespace Game.Card
{
    [CreateAssetMenu(fileName = "CardAnimationConfig", menuName = "Configs/CardAnimationConfig")]
    public class AnimationConfig : ScriptableObject
    {
        [Range(0, 5)] public float FlipAnimationDuration = 1f;
    }
}