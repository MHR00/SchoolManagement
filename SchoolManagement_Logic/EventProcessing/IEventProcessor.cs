﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Logic.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
