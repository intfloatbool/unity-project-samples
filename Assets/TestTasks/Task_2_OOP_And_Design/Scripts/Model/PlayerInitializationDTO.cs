using TestTasks.Task_2_OOP_And_Design.Scripts.Modules;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Model
{
    public class PlayerInitializationDTO
    {
        public readonly PlayerInfoBase PlayerInfo;
        public readonly IPossibleModulesProvider PossibleModulesProvider;

        public PlayerInitializationDTO(PlayerInfoBase playerInfo, IPossibleModulesProvider possibleModulesProvider)
        {
            PlayerInfo = playerInfo;
            PossibleModulesProvider = possibleModulesProvider;
        }
    }
}