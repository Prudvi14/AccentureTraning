using LHM.Models;

namespace LHM.Repository
{
    public interface ILHMRepo
    {
        bool AddPatient(Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        bool AddAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
    }
}