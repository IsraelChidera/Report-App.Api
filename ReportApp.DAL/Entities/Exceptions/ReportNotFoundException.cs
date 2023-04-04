namespace ReportApp.DAL.Entities.Exceptions
{
    public sealed class ReportNotFoundException : NotFoundException
    {
        public ReportNotFoundException(Guid reportId)
            : base($"The user with id:{reportId} doesn't exist in the database.")
        {

        }
    }
}
