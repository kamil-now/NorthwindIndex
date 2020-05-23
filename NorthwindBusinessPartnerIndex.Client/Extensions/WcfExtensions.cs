using System;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Client.Extensions
{
    public static class WcfExtensions
    {
        public static K Using<T, K>(this T client, Func<T, K> work)
            where T : ICommunicationObject
        {
            K retval = default;
            try
            {
                retval = work(client);
                client.Close();
            }
            catch
            {
                client.Abort();
            }

            return retval;
        }
    }
}
