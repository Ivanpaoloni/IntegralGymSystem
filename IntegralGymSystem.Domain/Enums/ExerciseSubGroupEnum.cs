using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralGymSystem.Domain.Enums
{
    public enum ExerciseSubGroupEnum
    {
        // Subgrupos para Parte superior del cuerpo
        [Description("Pecho")]
        Chest = 1,

        [Description("Espalda")]
        Back = 2,

        [Description("Hombros")]
        Shoulders = 3,

        // Subgrupos para brazos
        [Description("Bíceps")]
        Biceps = 4,

        [Description("Tríceps")]
        Triceps = 5,

        // Subgrupos para Parte inferior del cuerpo
        [Description("Cuádriceps")]
        Quadriceps = 6,

        [Description("Isquiotibiales")]
        Hamstrings = 7,

        [Description("Glúteos")]
        Glutes = 8,

        [Description("Pantorrillas")]
        Calves = 9,

        [Description("Abductores")]
        Abductors = 10,

        [Description("Aductores")]
        Adductors = 11,

        // Subgrupos para Core
        [Description("Abdominales")]
        Abs = 12,

        [Description("Oblicuos")]
        Obliques = 13,

        // Subgrupos para Cardio
        [Description("Correr")]
        Running = 14,

        [Description("Ciclismo")]
        Cycling = 15,

        [Description("Saltar la cuerda")]
        JumpRope = 16,

        // Subgrupos para Estiramientos
        [Description("Estiramientos dinámicos")]
        DynamicStretching = 17,

        [Description("Estiramientos estáticos")]
        StaticStretching = 18,

        // Subgrupos para Cuerpo completo
        [Description("Entrenamiento HIIT")]
        HIIT = 19,

        [Description("Entrenamiento en circuito")]
        CircuitTraining = 20,

        // Otros
        [Description("Otros")]
        Other = 21
    }
}
