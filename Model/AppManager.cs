using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace Model
{
    public class AppManager : INotifyPropertyChanged
    {
        List<string> orderedMonthsList = new List<string>()
        {
            "January","February", "March", "April", "May", "Juin","July", "August", "September",
            "October","November" ,"December"
        };
        public string CurrentMonth { get; private set; } = DateTime.Now.ToString("MMMM yyyy");
        public ReadOnlyObservableCollection<Record> Records { get; private set; }
        private ObservableCollection<Record> records { get; set; } = new ObservableCollection<Record>()
        {

        };

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "Breakdown") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        IPersistance Persistance;
        public AppManager(IPersistance persistance)
        {
            Persistance = persistance;
            foreach (var r in persistance.LoadRecords())
            {
                records.Add(r);
            }
            Records = new ReadOnlyObservableCollection<Record>(records);
            UpdateBreakdown();
            UpdateCurrentMonth();
        }

        public IEnumerable Breakdown
        {
            get => breakdown;
            private set
            {
                breakdown = value;
                OnPropertyChanged();

            }
        }

        IEnumerable breakdown;

        public void UpdateBreakdown()
        {
            Breakdown = records.GroupBy(r => r.Month).
                    Select(
                        group => new { key = group.Key.ToString(), value = group.Sum(r => r.Money) }
                    ).OrderBy(r => orderedMonthsList.IndexOf(r.key));
        }

        public float CurrentMonthSum
        {
            get => currentMonthSum;
            private set
            {
                currentMonthSum = value;
                OnPropertyChanged();
            }
        }

        public float currentMonthSum;

        public IEnumerable CurrentMonthRecords
        {
            get => currentMonthRecords;
            private set
            {
                currentMonthRecords = value;
                OnPropertyChanged();


            }
        }

        IEnumerable currentMonthRecords;

        public void UpdateCurrentMonth()
        {
            CurrentMonthRecords = records.Where(r => r.Month == DateTime.Now.ToString("MMMM"));
            CurrentMonthSum = records.Where(r => r.Month == DateTime.Now.ToString("MMMM")).Sum(r => r.Money);
        }

        public void AddRecord(Record r)
        {
            records.Add(r);
            Persistance.AddRecord(r);
            UpdateBreakdown();
            UpdateCurrentMonth();
        }

        public void RemoveRecord(Record r)
        {
            records.Remove(r);
            Persistance.RemoveRecord(r);
            UpdateBreakdown();
            UpdateCurrentMonth();
        }

    }




}
