using LHM.Models;
using Microsoft.EntityFrameworkCore;

namespace LHM.Repository
{
    public class LHMRepo : ILHMRepo
    {
        private readonly LHMDbContext _context;

        public LHMRepo(LHMDbContext context)
        {
            _context = context;
        }

        public bool AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            return _context.SaveChanges() > 0;
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        public List<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public bool AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return _context.SaveChanges() > 0;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.Include(a => a.Patient).ToList();
        }
    }
}