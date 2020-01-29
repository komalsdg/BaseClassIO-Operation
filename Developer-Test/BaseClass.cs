using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Test
{
    public abstract class BaseClass
    {
        #region db file const
        private const string ProjectName = "Developer-Test";
        private const string DbFilePath = "dbFile\\dbData.txt";
        private static readonly string FilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\" + ProjectName + "\\" + DbFilePath));
        #endregion

        #region declaration
        protected static char cdelimiter = ';';
        public string Id { get; set; }
        public string TableName { private get; set; }
        enum RecordType
        {
            Customer,
            Company
        }
        #endregion

        #region methods
        public void CreateId()
        {
            this.Id = this.GetHashCode().ToString();
        }

        public void Save()
        {
            this.CreateId();
            if (Find(this.Id) != null)
            {
                this.Delete();
                this.Id = null;
            }
            else
            {
                using (StreamWriter writer = File.AppendText(FilePath))
                {
                    writer.WriteLine(this.ToString());
                }
            }
        }

        public void Delete()
        {
            string[] extractlines = File.ReadAllLines(FilePath).Where(r => r.Split(cdelimiter).ToList().ElementAt(1) != this.Id).ToArray();
            File.WriteAllLines(FilePath, extractlines);
            this.Id = null;
        }

        public static BaseClass Find(string id)
        {
            var fs = new FileStream(FilePath, FileMode.OpenOrCreate);
            using (StreamReader rdr = new StreamReader(fs))
            {
                string line;

                while ((line = rdr.ReadLine()) != null)
                {
                    var record = line.Split(cdelimiter);
                    if (record.Length > 1)
                    {
                        if (record[1] == id)
                        {
                            switch ((RecordType)Enum.Parse(typeof(RecordType), record[0], true))
                            {
                                case RecordType.Customer:
                                    return new Customer(line);
                                case RecordType.Company:
                                    return new Company(line);
                            }
                        }
                    }
                }
                return null;
            }
        }
        #endregion
    }
}
