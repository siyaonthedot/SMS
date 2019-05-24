﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BusinesLogicModel
{
    public class ActionResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
        public ActionResult(bool success)
        {
            Success = success;
        }
        public ActionResult()
        {
        }



    }
}
