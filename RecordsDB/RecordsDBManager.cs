using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace RecordsDB
{
    public class RecordsDBManager : IPersistance
    {
        public bool AddRecord(Record r)
        {
            Record AddedRecord = null;
            using (RecordsContext context = new RecordsContext())
            {
                AddedRecord = context.Records.Add(r)?.Entity; //si add succesful returns object.Entity
                if (AddedRecord != null) context.SaveChanges(); 
            }                                           //si nn, returns null
            return AddedRecord != null;
        }

        public IEnumerable<Record> LoadRecords()
        {
            List<Record> records = new List<Record>();

            using(RecordsContext context = new RecordsContext())
            {
                records.AddRange(context.Records);   
            }
            return records;

        }

        public bool RemoveRecord(Record r)
        {
            using (RecordsContext context = new RecordsContext())
            {
                context.Records.Remove(r);
                context.SaveChanges();
            }
            return true;
        }
    }
}
