﻿using lndapi.Base;
using lndapi.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lndapi
{
    public partial class LNDynamic
    {
        public async Task VMResizeAsync(int vmId, int planId)
        {
            // TODO If local storage is in use, can't go down in disk size
            //      API reports success if this is attempted, but in reality nothing happens.
            //      Should I ask them to report failure in this scenario, or do I check if the resize is impossible and throw an exception?
            //      Just got an email saying resize failed.  It also indicates resizing when installing from ISO is also impossible
            await RequestAsync<BaseResponseModel>("vm", "resize", new VMResizeRequestModel(vmId, planId));
        }
    }
}

namespace lndapi.VM
{
    public class VMResizeRequestModel : VMBaseRequestModel
    {
        public int plan_id { get; set; }

        public VMResizeRequestModel(int vmId, int planId) : base(vmId)
        {
            this.plan_id = planId;
        }
    }
}
