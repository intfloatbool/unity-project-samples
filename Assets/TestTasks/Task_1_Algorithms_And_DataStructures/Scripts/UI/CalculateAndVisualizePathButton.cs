using Common.Scripts;
using UnityEngine;

namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.UI
{
    public class CalculateAndVisualizePathButton : ButtonHandlerBase
    {
        [SerializeField] private PathVisualizator _pathVisualizator;
        protected override void OnClick()
        {
           if(!_pathVisualizator)
               return;

           _pathVisualizator.Show();
        }
    }
}