using System.Collections.Generic;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Modules
{
    public interface IPossibleModulesProvider
    {
        IEnumerable<ModuleBase> ProvidePossibleModules();
    }
}