using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Test
{
    public class Address : BaseClass
    {
        #region declaration
        public string Addrs { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        #endregion

        #region constructor
        public Address(string record)
        {
            string[] recorddata = record.Split(cdelimiter);
            this.Addrs = recorddata[0];
            this.City = recorddata[1];
            this.State = recorddata[2];
            this.PinCode = recorddata[3];
        }

        public Address(string addrs, string city, string state, string pincode)
        {
            this.Addrs = addrs;
            this.City = city;
            this.State = state;
            this.PinCode = pincode;
        }
        #endregion

        #region methods
        public new static Address Find(string id)
        {
            return (Address)BaseClass.Find(id);
        }
        #endregion

        #region overriden
        public override string ToString()
        {
            return string.Join(cdelimiter.ToString(), new[] { this.Addrs, this.City, this.State, this.PinCode });
        }

        public override bool Equals(object obj)
        {
            if (obj is Address)
            {
                Address a = (Address)obj;
                return Equals(a.Addrs, this.Addrs) && Equals(a.City, this.City) && Equals(a.State, this.State) && Equals(a.PinCode, this.PinCode);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Addrs.GetHashCode() ^ City.GetHashCode() ^ State.GetHashCode() ^ PinCode.GetHashCode();
        }
        #endregion
    }
}
