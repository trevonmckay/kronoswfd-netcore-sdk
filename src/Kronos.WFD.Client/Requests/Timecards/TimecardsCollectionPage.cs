namespace Kronos.WFD.Client.Requests
{
    public class TimecardsCollectionPage : CollectionPage<EmployeeTimecard>, ITimecardsCollectionPage
    {
    }

    public interface ITimecardsCollectionPage : ICollectionPage<EmployeeTimecard>
    {

    }
}
