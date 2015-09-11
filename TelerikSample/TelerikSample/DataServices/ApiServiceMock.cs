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
                Property = "Happy Hollows (11111)",
                AcctManager = "Erik Dahl",
                AcctMgrPhone = "545-867-5309",
                AcctMgrEmail = "me@knowhere.com",
                PropSvcRep = "Weston Thomas",
                PsrPhone = "454-867-5309",
                PsrEmail = "him@knowhere.com",
                InstanceId = "12345",
                CreatedAtDt = new System.DateTime(2015,9,1,17,5,3),
                Details = new Dictionary<string, object>()                
            });

            return list;
        }
    }
}
