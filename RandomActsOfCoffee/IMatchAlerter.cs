﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities;

namespace RandomActsOfCoffee
{
    public interface IMatchAlerter
    {
        void AlertMatches(IEnumerable<Match> matches);
    }
}
