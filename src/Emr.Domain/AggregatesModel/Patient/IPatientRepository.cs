namespace Emr.Domain.AggregatesModel.Patient
{
    public interface IPatientRepository
    {
        List<emrpatient> GetPatientFull();
    }
}
