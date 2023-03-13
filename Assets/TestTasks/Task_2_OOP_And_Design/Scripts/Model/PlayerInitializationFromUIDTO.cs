using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;
using TestTasks.Task_2_OOP_And_Design.Scripts.UI;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Model
{
    public class PlayerInitializationFromUIDTO : PlayerInitializationDTO
    {
        public readonly ModulesUIElementsCreator UIElementsCreator;
        public PlayerInitializationFromUIDTO(ModulesUIElementsCreator uiElementsCreator,PlayerInfoBase playerInfo, IPossibleModulesProvider possibleModulesProvider) : base(playerInfo, possibleModulesProvider)
        {
            UIElementsCreator = uiElementsCreator;
        }
    }
}