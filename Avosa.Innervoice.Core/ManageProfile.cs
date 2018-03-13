using Avosa.Innervoice.Data;
using System;

namespace Avosa.Innervoice.Core
{
    public class ManageProfile : IManageProfile
    {
        private readonly IStorage _context;

        public ManageProfile(IStorage context)
        {
            _context = context;
        }

        public Confirmer Create(Profile profile)
        {
            var result = new Confirmer();

            try
            {
                _context.Profiles.Add(profile);
                _context.Save();
            }
            catch (Exception exc)
            {
                result.SetError(exc.ToString());
            }

            return result;
        }
    }
}
