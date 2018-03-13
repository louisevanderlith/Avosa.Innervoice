using Avosa.Innervoice.Data;

namespace Avosa.Innervoice.Core
{
    public interface IManageProfile
    {
        Confirmer Create(Profile profile);
    }
}
