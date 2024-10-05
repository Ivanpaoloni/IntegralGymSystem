using System.ComponentModel;

namespace IntegralGymSystem.Domain.Enums
{
    public enum ExerciseTypeEnum
    {
        [Description("Upper Body: Chest")]
        Chest = 1,
        [Description("Upper Body: Back")]
        Back = 2,
        [Description("Upper Body: Shoulders")]
        Shoulders = 3,
        [Description("Upper Body: Arms")]
        Arms = 4,
        [Description("Lower Body: Legs")]
        Legs = 5,
        [Description("Lower Body: Glutes")]
        Glutes = 6,
        [Description("Core: Abs")]
        Abs = 7,
        [Description("Cardio")]
        Cardio = 8,
        [Description("Stretching")]
        Stretching = 9,
        [Description("Full Body")]
        FullBody = 10,
        [Description("Other")]
        Other = 11
    }

}
