
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Samples;
using PayoutsSdk.Payouts;
using PayoutsSdk.Core;
using PayPalHttp;

using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
namespace Samples
{
    public class GetPayoutItemSample
    {
        public async static Task<HttpResponse> GetPayoutItem(string itemId,bool debug = false)
        {

            PayoutsItemGetRequest request = new PayoutsItemGetRequest(itemId);
            var getResponse = await PayPalClient.client().Execute(request);
            var result = getResponse.Result<PayoutItemResponse>();
            if (debug)
            {
                Console.WriteLine("Batch: {0}", result.PayoutBatchId);
                Console.WriteLine("Item: {0}", result.PayoutItemId);
                Console.WriteLine("Links:");
                foreach (LinkDescription link in result.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }

            }
            return getResponse;
        }

        /*static void Main(string[] args)
        {
            var response = CreatePayoutSample.CreatePayout(true);
            HttpResponse createPayoutResponse = response.Result;
            var payout = createPayoutResponse.Result<CreatePayoutResponse>();
            
            var getResponse = GetPayoutSample.GetPayout(payout.BatchHeader.PayoutBatchId,true);
            HttpResponse getPayoutResponse = getResponse.Result;
            var payoutBatch = getPayoutResponse.Result<PayoutBatch>();

            GetPayoutItem(payoutBatch.Items[0].PayoutItemId,true).Wait();
        }*/
    }
}