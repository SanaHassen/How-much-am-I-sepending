using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
        public interface IPersistance
        {
            IEnumerable<Record> LoadRecords();
            bool AddRecord(Record r);

            bool RemoveRecord(Record r);

        }
    }

