﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MyAngle
{
    struct Angle
    {
        private int _degree;
        private int _minute;
        private int _second;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"{_degree,3}°  {_minute, 3}\' {_second, 3}\"";
        }

        #region Any helpful function
        //public void ToAngle()
        //{
        //    if (Math.Abs(_second) >= 60)
        //    {
        //        _minute += _second / 60;
        //        _second = _second % 60;
        //    }
        //    if (Math.Abs(_minute) >= 60)
        //    {
        //        _degree += _minute / 60;
        //        _minute = _minute % 60;
        //    }
        //    if (Math.Abs(_degree) >= 360)
        //        _degree = _degree - 360 * (_degree / 360);
        //}
        public void ToPositivAngle()
        {

            int temp = _second + _minute * 60 + _degree * 3600;
            if (temp < 0)
                temp += 360 * 3600;
            _second = temp % 60;
            _minute = (temp / 60) % 60;
            _degree = (temp / 3600) % 360;
        }
        private int ToSeconds()
        {
            return _second + _minute * 60 + _degree * 3600;
        }
        public static Angle ToAngle(int n)
        {
            Angle a;
            a._second = n % 60;
            a._minute = (n / 60) % 60;
            a._degree = (n / 3600) % 360;
            return a;
        }

        #endregion

        #region Constructors
        public Angle(int degree, int minute, int second)
        {
            _degree = degree;
            _minute = minute;
            _second = second;
            ToPositivAngle();
        }
        public Angle (int degree,int minute)
        {
            _degree = degree;
            _minute = minute;
            _second = 0;
            ToPositivAngle();
        }
        public Angle(int degree)
        {
            _degree = degree;
            _minute = 0;
            _second = 0;
            ToPositivAngle();
        }

        #endregion
        
        #region Arithmetic Operators
        public static Angle operator +(Angle a1,Angle a2)
        {
            a1._degree += a2._degree;
            a1._minute += a2._minute;
            a1._second += a2._second;
            a1.ToPositivAngle();
            return a1;
        }
        public static Angle operator -(Angle a1, Angle a2)
        {
            a1._degree -= a2._degree;
            a1._minute -= a2._minute;
            a1._second -= a2._second;
            a1.ToPositivAngle();
            return a1;
        }
        public static Angle operator *(Angle a, int n)
        {
            a._degree *= n;
            a._minute *= n;
            a._second *= n;
            a.ToPositivAngle();
            return a;
        }
        public static Angle operator /(Angle a, int n)
        {
            int temp = (a.ToSeconds()) / n;
            a = ToAngle(temp);
            return a;
        }
        #endregion

        #region Logical Operators
        public static bool operator ==(Angle a1, Angle a2)
        {
            return (a1._degree == a2._degree && a1._minute == a2._minute && a1._second == a2._second);
        }
        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1==a2);
        }
        public static bool operator >(Angle a1,Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            return (a1.ToSeconds() > a2.ToSeconds());
        }
        public static bool operator <(Angle a1, Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            return (a1.ToSeconds() < a2.ToSeconds());
        }
        public static bool operator >=(Angle a1, Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            return (a1.ToSeconds() >= a2.ToSeconds());
        }
        public static bool operator <=(Angle a1, Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            return (a1.ToSeconds() <= a2.ToSeconds());
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {

            Angle myAngle1 = new Angle(3,36,53);
            WriteLine("myAngle1 \t"+myAngle1);
  
            Angle myAngle2 = new Angle(4,27,45);
            WriteLine("myAngle2 \t" + myAngle2);

            WriteLine("\n");
            WriteLine("Arithmetics operations");
            WriteLine("{0}  +  {1}   =   {2}", myAngle1, myAngle2, myAngle1 + myAngle2);
            WriteLine("{0}  -  {1}   =   {2}", myAngle1, myAngle2, myAngle1 - myAngle2);
            WriteLine("\n");

            WriteLine("Compare 2 angles");
            if (myAngle1 > myAngle2)
                WriteLine("myAngle1     >  myAngle2 \n{0}  >  {1}", myAngle1.ToString(),myAngle2.ToString());
            else
                if (myAngle1 < myAngle2)
                    WriteLine("myAngle1     <  myAngle2 \n{0}  <  {1}", myAngle1.ToString(), myAngle2.ToString());
                else
                    WriteLine("myAngle1     =  myAngle2 \n{0}  =  {1}", myAngle1.ToString(), myAngle2.ToString());
            WriteLine("\n");

            WriteLine("Increase an angle");
            int n = 8;
            WriteLine("{0}    * {1} = {2}", myAngle1, n, myAngle1 * n);

            WriteLine("Decrease an angle");
            WriteLine("{0}    / {1} = {2}", myAngle1, n, myAngle1 / n);

            ReadKey();
        }
    }
}
