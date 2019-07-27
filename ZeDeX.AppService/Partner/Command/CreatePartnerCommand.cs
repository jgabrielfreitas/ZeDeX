using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.AppService.Partner.Command
{
    public class CreatePartnerCommand
    {
        public Owner owner { get; set; }
        public Pdv pdv { get; set; }
    }

    public class Owner
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class CoverageArea
    {
        public string type { get; set; }
        public List<List<List<List<int>>>> coordinates { get; set; }
    }

    public class Address
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Pdv
    {
        public string document { get; set; }
        public string name { get; set; }
        public CoverageArea coverageArea { get; set; }
        public Address address { get; set; }
    }
}
