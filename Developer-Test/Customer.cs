using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Test
{
    public class Customer:BaseClass
    {
        #region declaration
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string id;
        public readonly string RecordType = "Customer";
        public readonly Address Address;
        #endregion

        #region constructor
        public Customer(string record)
        {
            string[] recorddata = record.Split(cdelimiter);
            base.Id = recorddata[1];
            this.FirstName = recorddata[2];
            this.LastName = recorddata[3];
            string[] addrsdata = recorddata.Skip(4).ToArray();
            this.Address = new Address(string.Join(Convert.ToString(cdelimiter), addrsdata));
        }

        public Customer(string firstName, string lastName, Address address)
        {
            this.id = base.Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
        #endregion

        #region methods
        public new static Customer Find(string id)
        {
            return (Customer)BaseClass.Find(id);
        }
        #endregion

        #region overriden
        public override string ToString()
        {
            return string.Join(cdelimiter.ToString(), new[] { this.RecordType, base.Id, this.FirstName, this.LastName, Convert.ToString(this.Address) });
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                Customer p = (Customer)obj;
                return Equals(p.FirstName, this.FirstName) && Equals(p.LastName, this.LastName) && Equals(p.Address, this.Address);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Address.GetHashCode();
        }
        #endregion
    }
}
