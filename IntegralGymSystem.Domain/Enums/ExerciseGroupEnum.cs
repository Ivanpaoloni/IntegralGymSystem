using System.ComponentModel;

namespace IntegralGymSystem.Domain.Enums
{
    public enum ExerciseGroupEnum
    {
        [Description("Parte superior del cuerpo")]
        UpperBody = 1,

        [Description("Parte inferior del cuerpo")]
        LowerBody = 2,

        [Description("Core")]
        Core = 3,

        [Description("Cardio")]
        Cardio = 4,

        [Description("Estiramientos")]
        Stretching = 5,

        [Description("Cuerpo completo")]
        FullBody = 6,

        [Description("Otros")]
        Other = 7
    }


}
