using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Test
{
    public class Company:BaseClass
    {
        #region declaration
        public readonly string Name;
        public readonly string id;
        public readonly string RecordType = "Company";
        public readonly Address Address;
        #endregion

        #region constructor
        public Company(string record)
        {
            string[] recorddata = record.Split(cdelimiter);
            base.Id = recorddata[1];
            this.Name = recorddata[2];
            string[] addrsdata = recorddata.Skip(3).ToArray();
            this.Address = new Address(string.Join(Convert.ToString(cdelimiter), addrsdata));
        }

        public Company(string businessName, Address address)
        {
            this.id = base.Id;
            this.Name = businessName;
            this.Address = address;
        }
        #endregion

        #region methods
        public new static Company Find(string id)
        {
            return (Company)BaseClass.Find(id);
        }
        #endregion

        #region overriden
        public override string ToString()
        {
            return string.Join(cdelimiter.ToString(), new[] { this.RecordType, base.Id, this.Name, Convert.ToString(this.Address) });
        }

        public override bool Equals(object obj)
        {
            if (obj is Company)
            {
                Company biz = (Company)obj;
                return Equals(biz.Name, this.Name) && Equals(biz.Address, this.Address);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Address.GetHashCode();
        }
        #endregion
    }
}
