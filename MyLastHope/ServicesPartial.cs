using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLastHope
{
    public partial class Services
    {
        public bool IsDiscountExist { get => Discount > 0; }
        public double CostWithDoscount { get => (double)Cost * (1 - (double)Discount); }
        public double DurationInMinute { get => (double)DurationInSeconds / 60; }
    }
}
