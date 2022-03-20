using System;
using RecordsDB;
using Model;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RecordsContext context = new RecordsContext()) // ouvre une connexion avec la base de données
            {
                context.Records.Add(new Record(100, "essence", "January"));
                context.Records.Add(new Record(320, "loyer", "February"));
                context.Records.Add(new Record(35, "nourriture", "February"));
                context.Records.Add(new Record(10, "internet", "February"));
                context.SaveChanges(); //ecrit dans la base de données
            }

        }
    }
}
