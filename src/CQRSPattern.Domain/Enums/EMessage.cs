using System.ComponentModel;

namespace CQRSPattern.Domain.Enums;

public enum EMessage : ushort
{
    [Description("{0} has invalid length. It should be {1}.")]
    InvalidLength,

    [Description("{0} was not found.")]
    NotFound
}
