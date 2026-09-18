using NewLifeHospital.Models;

namespace NewLifeHospital.DataAccess
{
    public class Repository : IRepository
    {
        private readonly PatientInfoDbContext _context;

        public Repository(PatientInfoDbContext context)
        {
            _context = context;
        }

        public bool RegisterForMembership(PatientInfoDetail pObj)
        {
            try
            {
                _context.PatientInfoDetails.Add(pObj);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CancelMembership(int registrationId)
        {
            try
            {
                PatientInfoDetail? patient =
                    _context.PatientInfoDetails
                    .FirstOrDefault(p => p.RegistrationID == registrationId);

                if (patient == null)
                {
                    return false;
                }

                _context.PatientInfoDetails.Remove(patient);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEmail(int registrationId, string email)
        {
            try
            {
                PatientInfoDetail? patient =
                    _context.PatientInfoDetails
                    .FirstOrDefault(p => p.RegistrationID == registrationId);

                if (patient == null)
                {
                    return false;
                }

                patient.EmailID = email;
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}