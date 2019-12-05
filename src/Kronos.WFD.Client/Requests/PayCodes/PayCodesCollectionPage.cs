using System;
using System.Collections.Generic;
using System.Text;

namespace Kronos.WFD.Client.Requests
{
    public class PayCodesCollectionPage : CollectionPage<PayCode>, IPayCodesCollectionPage
    {
    }

    public interface IPayCodesCollectionPage : ICollectionPage<PayCode>
    {

    }
}
