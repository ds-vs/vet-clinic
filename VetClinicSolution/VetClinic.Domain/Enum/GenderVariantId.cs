using System.ComponentModel;

namespace VetClinic.Domain.Enum
{
    public enum GenderVariantId: int
    {
        [Description("Мальчик")]
        Male = 0,
        [Description("Девочка")]
        Female = 1,
        [Description("Кастрат")]
        Сastrato = 2,
    }
}
