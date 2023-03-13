using System.Collections.Generic;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules
{
    public class MacroModule : ModuleBase
    {
        private List<ModuleBase> _subModulesCollection;

        public MacroModule(params ModuleBase[] modules)
        {
            _subModulesCollection = new List<ModuleBase>(modules);
        }
        
        public override void OnStart()
        {
            foreach (var submodule in _subModulesCollection)
            {
                submodule.OnStart();
            }
        }

        public override void OnStop()
        {
            foreach (var submodule in _subModulesCollection)
            {
                submodule.OnStop();
            }
        }

        public override void OnFrame()
        {
            foreach (var submodule in _subModulesCollection)
            {
                submodule.OnFrame();
            }
        }
    }
}