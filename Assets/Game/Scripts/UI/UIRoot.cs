using UnityEngine;

namespace Game.UI
{
    public class UIRoot : MonoBehaviour
    {
        public Transform ActiveContainer => activeContainer;
        public Transform DeactiveContainer => deactiveContainer;
        public Canvas Canvas => canvas;
        
        [SerializeField] private Transform activeContainer;
        [SerializeField] private Transform deactiveContainer;
        [SerializeField] private Canvas canvas;
    }
}