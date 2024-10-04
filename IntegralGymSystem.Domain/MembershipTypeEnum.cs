using System.ComponentModel;

namespace IntegralGymSystem.Domain
{
    public enum MembershipTypeEnum
    {
        [Description("Super Administrador")]
        SuperAdmin = 1,
        [Description("Administrador")]
        Admin = 2,
        [Description("Instructor")]
        Instructor = 3,
        [Description("Miembro")]
        Member = 4
    }
}
