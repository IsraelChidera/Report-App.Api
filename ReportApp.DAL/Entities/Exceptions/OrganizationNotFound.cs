namespace ReportApp.DAL.Entities.Exceptions
{
    public sealed class OrganizationNotFound : NotFoundException
    {
        public OrganizationNotFound(string organizatioName)
            : base($"The organization with username:{organizatioName} doesn't exist in the database.")
        {

        }
    }
}
