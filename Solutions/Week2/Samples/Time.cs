using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class Time
    {
        // Ctrl + K, Ctrl + X -> surround code with ... 
        #region Data Members

        private int minute;
        private int second;
        private int hour;

        #endregion

        #region Constructors
        /// <summary>
        /// General- purpose constructor
        /// </summary>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="hour"></param>
        public Time(int minute, int second, int hour)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public Time()
        {

        }

        public Time(ref readonly Time time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;
        }

        #endregion

        #region Properties

        public int Second
        {
            get => second;
            set => second = value >= 0 && value < 60 ? value : 0;
        }

        public int Hour
        {
            get => hour;
            set => hour = value >= 0 && value < 24 ? value : 0;
        }

        public int Minute
        {
            get => minute;
            set => minute = value >= 0 && value < 60 ? value : 0;
        }

        #endregion

        public void ChangeTime((int s, int m, int h) time)
        {
            Hour = time.m;  // if property has init instead of set, won't compile
            Second = time.s; 
        }

        public override string ToString()
         => $"{Hour:D2}:{Minute:D2}:{Second:D2}";


    }
}