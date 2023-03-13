using System.Collections.Generic;
using TestTasks.Task_2_OOP_And_Design.Scripts.Model;
using UnityEngine;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.GameStates.States
{
    public abstract class GameStateBase : ITickableCommand
    {
        protected readonly GameFSM _gameFsm;
        protected IEnumerable<GameObject> _relativeGameObjects;

        public GameStateBase(GameFSM gameFsm, params GameObject[] relativeGameObjects)
        {
            _gameFsm = gameFsm;
            _relativeGameObjects = relativeGameObjects;
        }

        public virtual void OnStart()
        {
            SetActiveGameObjects(true);
        }

        public virtual void OnStop()
        {
            SetActiveGameObjects(false);
        }

        protected virtual void SetActiveGameObjects(bool isActive)
        {
            foreach (var go in _relativeGameObjects)
            {
                if(go && go.activeSelf != isActive)
                    go.SetActive(isActive);
            }
        }

        public virtual void OnFrame() {}
    }
}