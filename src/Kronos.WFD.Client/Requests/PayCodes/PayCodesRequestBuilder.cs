namespace Kronos.WFD.Client.Requests
{
    public class PayCodesRequestBuilder : BaseRequestBuilder, IPayCodesRequestBuilder
    {
        public PayCodesRequestBuilder(string requestUrl, IBaseClient client)
            : base(requestUrl, client)
        {
        }

        public IPayCodesCollectionRequestBuilder Employee
        {
            get
            {
                return new PaycodesCollectionRequestBuilder(this.AppendSegmentToRequestUrl("employee_pay_codes"), this.Client);
            }
        }

        public IPayCodesCollectionRequestBuilder Manager
        {
            get
            {
                return new PaycodesCollectionRequestBuilder(this.AppendSegmentToRequestUrl("pay_codes"), this.Client);
            }
        }
    }

    public interface IPayCodesRequestBuilder : IBaseRequestBuilder
    {
        IPayCodesCollectionRequestBuilder Employee { get; }

        IPayCodesCollectionRequestBuilder Manager { get; }
    }
}
