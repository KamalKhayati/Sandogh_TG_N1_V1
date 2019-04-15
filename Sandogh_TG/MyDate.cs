﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_TG
{
    public class Mydate
    {
        private int _Year;
        private int _Month;
        private int _day;

        private static int[] MonthDays = { 0, 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 };

        public int Year
        {
            get => _Year;
            set => _Year = value;
            //set => _Year = value >= 1397 && value <= 2000 ? value : 1397;
        }
        public int Month
        {
            get => _Month;
            set => _Month = value >= 1 && value <= 12 ? value : 1;
        }
        public int Day
        {
            get => _day;
            set => _day = value >= 1 && value <= MonthDays[Month] ? value : 1;
        }

        public Mydate(int y, int m, int d)
        {
            Year = y;
            Month = m;
            Day = d;
        }
        public Mydate()
        {
        }

        public Mydate(Mydate x)
        {
            Year = x.Year;
            Month = x.Month;
            Day = x.Day;
        }

        public bool EndOFMonth()
        {
            return Day == MonthDays[Month];
        }

        public void Increment()
        {
            if (Month == 12 && EndOFMonth())
            {
                Year++;
                Month = 1;
                Day = 1;
            }
            else if (EndOFMonth())
            {
                Month++;
                Day = 1;
            }
            else
                Day++;
        }
        public void IncrementMonth()
        {
            if (Month == 12)
            {
                Year++;
                Month = 1;
                //Day = 1;
            }
            else
            {
                Month++;
                //Day = 1;
            }
            //else
            //    Day++;
        }
        public void IncrementYear()
        {
            Year++;
        }

        public void Decrement()
        {
            if (Month == 1 && Day == 1)
            {
                Year--;
                Month = 12;
                Day = MonthDays[Month];
            }
            else if (Day == 1)
            {
                Month--;
                Day = MonthDays[Month];
            }
            else
                Day--;
        }

        public override string ToString()
        {
            return Year.ToString() + "/" + (Month < 10 ? "0" : "") + Month.ToString() + "/" + (Day < 10 ? "0" : "") + Day.ToString();
        }

        public Mydate Add1(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Increment();
            }
            return this;
        }

        public Mydate Add2(int n)
        {
            Mydate t = new Mydate(this);
            for (int i = 1; i <= n; i++)
            {
                t.Increment();
            }
            return t;
        }

        public static Mydate operator +(Mydate x, int n)
        {
            Mydate temp = new Mydate(x);
            for (int i = 0; i < n; i++)
            {
                temp.Increment();
            }
            return temp;
        }
        public static Mydate operator +(int n, Mydate x)
        {
            Mydate temp = new Mydate(x);
            for (int i = 0; i < n; i++)
            {
                temp.Increment();

            }
            return temp;
        }
        public static Mydate operator -(Mydate x, int n)
        {
            Mydate temp = new Mydate(x);
            for (int i = 0; i < n; i++)
            {
                temp.Decrement();
            }
            return temp;
        }
        public static Mydate operator -(int n, Mydate x)
        {
            Mydate temp = new Mydate(x);
            for (int i = 0; i < n; i++)
            {
                temp.Decrement();

            }
            return temp;
        }
        public static int operator -(Mydate DateNow, Mydate Sarresid)
        {
            int dd = 0;
            Mydate date1 = new Mydate(DateNow);
            Mydate date2 = new Mydate(Sarresid);
            while (true)
            {
                date1.Increment();
                if (date1 < date2)
                    dd++;
                else
                    return dd;
            }

        }

        public static int IncrementM(Mydate DateNow, Mydate Sarresid)
        {
            int MM = 0;
            Mydate date1 = new Mydate(DateNow);
            Mydate date2 = new Mydate(Sarresid);
            while (true)
            {
                date1.IncrementMonth();

                if (date1 < date2 || date1 == date2)
                    MM++;
                else
                    return MM;
            }
        }
        public static int IncrementY(Mydate DateNow, Mydate Sarresid)
        {
            int yy = 0;
            Mydate date1 = new Mydate(DateNow);
            Mydate date2 = new Mydate(Sarresid);
            while (true)
            {
                date1.IncrementYear();

                if (date1 < date2 || date1 == date2)
                    yy++;
                else
                    return yy;
            }
        }

        public static bool operator >(Mydate x, Mydate y) => x.Year > y.Year || (x.Year == y.Year && x.Month > y.Month) || (x.Year == y.Year && x.Month == y.Month && x.Day > y.Day);
        public static bool operator <(Mydate x, Mydate y) => x.Year < y.Year || (x.Year == y.Year && x.Month < y.Month) || (x.Year == y.Year && x.Month == y.Month && x.Day < y.Day);
        public static bool operator ==(Mydate x, Mydate y) => x.Year == y.Year && x.Month == y.Month && x.Day == y.Day;
        public static bool operator !=(Mydate x, Mydate y) => x.Year != y.Year && x.Month != y.Month && x.Day != y.Day;

        public static Mydate operator ++(Mydate x)
        {
            var temp = new Mydate(x);
            temp.Increment();
            return temp;
        }
        public static Mydate operator --(Mydate x)
        {
            var temp = new Mydate(x);
            temp.Decrement();
            return temp;
        }

        public static explicit operator int(Mydate x)
        {
            int n = 0;
            for (int i = 1; i < x.Month; i++)
            {
                n += MonthDays[i];
            }
            return n + x.Day;
        }

        public static implicit operator string(Mydate x)
        {
            return x.ToString();
        }

        public static bool operator true(Mydate x)
        {
            return x.Day == 1 && x.Month == 1;
        }
        public static bool operator false(Mydate x)
        {
            return !(x.Day == 1 && x.Month == 1);
        }
    }
}
