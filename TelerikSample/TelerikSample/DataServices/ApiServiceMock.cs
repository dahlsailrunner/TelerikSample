using System;
using System.Collections.Generic;
using TelerikSample.Models;

namespace TelerikSample.DataServices
{
    public static class ApiServiceMock
    {
        internal static List<ActionItem> GetActionItems()
        {
            var list = new List<ActionItem>();

            list.Add(new ActionItem
            {
                ActionType = ActionItemType.PrebillingApproval,
                Description = "Prebilling Approval",
                Property = "Residences at Tattooine Village #20931 (22894)",
                AcctManager = "Erik Dahl",
                AcctMgrPhone = "545-867-5309",
                AcctMgrEmail = "me@knowhere.com",
                PropSvcRep = "Weston Thomas",
                PsrPhone = "454-867-5309",
                PsrEmail = "him@knowhere.com",
                InstanceId = "12345",
                CreatedAtDt = new System.DateTime(2015, 9, 1, 17, 5, 3),
                Details = new Dictionary<string, object>()
                {
                    {"CurrentBillCount", "212" },
                    {"PreviousBillCount", "208" },
                    {"PreviousAvgNormalBill", "48.29" },
                    { "CurrentAvgNormalBill", "49.02" },
                    {"PreviousBillingAmount", "3892.04" }
                }
            });

            list.Add(new ActionItem
            {
                ActionType = ActionItemType.PrebillingApproval,
                Description = "Prebilling Approval",
                Property = "Happy Hollows #8201 (23479)",
                AcctManager = "Erik Dahl",
                AcctMgrPhone = "545-867-5309",
                AcctMgrEmail = "me@knowhere.com",
                PropSvcRep = "Weston Thomas",
                PsrPhone = "454-867-5309",
                PsrEmail = "him@knowhere.com",
                InstanceId = "12345",
                CreatedAtDt = new System.DateTime(2015, 9, 1, 20, 5, 3),
                Details = new Dictionary<string, object>()
            });

            list.Add(new ActionItem
            {
                ActionType = ActionItemType.PrebillingApproval,
                Description = "Prebilling Approval",
                Property = "Residences at Tattooine Village #20931 (22894)",
                AcctManager = "Erik Dahl",
                AcctMgrPhone = "545-867-5309",
                AcctMgrEmail = "me@knowhere.com",
                PropSvcRep = "Weston Thomas",
                PsrPhone = "454-867-5309",
                PsrEmail = "him@knowhere.com",
                InstanceId = "12345",
                CreatedAtDt = new System.DateTime(2015, 9, 1, 17, 5, 3),
                Details = new Dictionary<string, object>()
                {
                    {"CurrentBillCount", "212" },
                    {"PreviousBillCount", "208" },
                    {"PreviousAvgNormalBill", "48.29" },
                    { "CurrentAvgNormalBill", "49.02" },
                    {"PreviousBillingAmount", "3892.04" }
                }
            });

            list.Add(new ActionItem
            {
                ActionType = ActionItemType.PrebillingApproval,
                Description = "Prebilling Approval",
                Property = "Residences at Tattooine Village #20931 (22894)",
                AcctManager = "Erik Dahl",
                AcctMgrPhone = "545-867-5309",
                AcctMgrEmail = "me@knowhere.com",
                PropSvcRep = "Weston Thomas",
                PsrPhone = "454-867-5309",
                PsrEmail = "him@knowhere.com",
                InstanceId = "12345",
                CreatedAtDt = new System.DateTime(2015, 9, 1, 17, 5, 3),
                Details = new Dictionary<string, object>()
                {
                    {"CurrentBillCount", "212" },
                    {"PreviousBillCount", "208" },
                    {"PreviousAvgNormalBill", "48.29" },
                    { "CurrentAvgNormalBill", "49.02" },
                    {"PreviousBillingAmount", "3892.04" }
                }
            });
            return list;
        }


        internal static LocalChart GetChartData()
        {
            var chart = new PbChart
            {
                SupplierId = "1234141",
                PerEndDt = "04132015"
            };
            var rng = new Random();
            for (var i = 0; i < rng.Next(60, 500); i++)
            {
                var x = rng.Next(0, 100);
                if (x <= 4)
                    chart.VacantCount++;
                else if (x < 10)
                    chart.Count_0_10++;
                else if (x < 20)
                    chart.Count_10_20++;
                else if (x < 30)
                    chart.Count_20_30++;
                else if (x < 40)
                    chart.Count_30_40++;
                else if (x < 50)
                    chart.Count_40_50++;
                else if (x < 60)
                    chart.Count_50_60++;
                else if (x < 70)
                    chart.Count_GT60++;
            }
            chart.TotalCurrentCharges = rng.Next(0, 10000);
            chart.BillableCount = chart.Count_GT60 + chart.Count_50_60 + chart.Count_40_50 + chart.Count_30_40 + chart.Count_20_30 + chart.Count_10_20 + chart.Count_0_10;
            return new LocalChart(chart);
        }
    }
}
