namespace TestTasks.Task_1_Algorithms_And_DataStructures.Scripts.BusinessLogic
{

    public enum EStationColorType : byte
    {
        NONE, RED, GREEN, BLUE, BLACK
    }
    
    public class SubwayStation
    {
        public string Label { get; private set; }
        public EStationColorType ColorType { get; private set; }

        private SubwayStation(string label, EStationColorType colorType)
        {
            Label = label;
            ColorType = colorType;
        }

        public static SubwayStation Create(string label, EStationColorType colorType)
        {
            return new SubwayStation(label, colorType);
        }
        
    }
}