using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Game.CardModule
{
    public class CardModuleView : MonoBehaviour
    {
        public Transform LeftSpawnPoint => leftSpawnPoint;
        public Transform RightSpawnPoint => rightSpawnPoint;
        
        [SerializeField] private Transform leftSpawnPoint;
        [SerializeField] private Transform rightSpawnPoint;

        public class Factory : PlaceholderFactory<CardModuleView>
        {}
    }
}