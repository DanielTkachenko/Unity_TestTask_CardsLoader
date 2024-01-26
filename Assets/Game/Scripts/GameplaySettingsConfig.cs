using Game.Card;
using Game.CardModule;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameplaySettingsConfig", menuName = "Configs/GameplaySettingsConfig")]
    public class GameplaySettingsConfig : ScriptableObject
    {
        //class for setting gameplay parameters
        public CardModel CardConfig => cardConfig;
        public CardModuleModel CardModuleConfig => cardModuleConfig;
        public CardAnimationModel CardAnimationConfig => cardAnimationConfig;
        
        [SerializeField] private CardModel cardConfig;
        [SerializeField] private CardAnimationModel cardAnimationConfig;
        [SerializeField] private CardModuleModel cardModuleConfig;
    }
}