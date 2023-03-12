using DG.Tweening;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts
{
    public class SceneInit : MonoBehaviour
    {
        private void Awake()
        {
            DOTween.useSafeMode = true;
        }
    }
}