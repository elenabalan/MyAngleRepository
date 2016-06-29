using System;
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

        #region Constructors
        public Angle(int degree, int minute, int second)
        {
            _degree = degree;
            _minute = minute;
            _second = second;
            ToAngle();
        }
        public Angle (int degree,int minute)
        {
            _degree = degree;
            _minute = minute;
            _second = 0;
            ToAngle();
        }
        public Angle(int degree)
        {
            _degree = degree;
            _minute = 0;
            _second = 0;
            ToAngle();
        }

        #endregion
        public void ToAngle()
        {
            if (Math.Abs(_second) >= 60)
            {
                _minute += _second / 60;
                _second = _second % 60;
            }
            if (Math.Abs(_minute) >= 60)
            {
                _degree += _minute / 60;
                _minute = _minute % 60;
            }
            if (Math.Abs(_degree) >= 360)
                _degree = _degree - 360 * (_degree / 360);
        }
        public void ToPositivAngle()
        {

            int temp = _second + _minute * 60 + _degree * 3600;
            if (temp < 0)
                temp += 360 * 3600;
            _second = temp % 60;
            // temp -= _second;
            _minute = (temp / 60) % 60;
            _degree = (temp / 3600) % 360;
        }
        public int ToSeconds()
        {
            return _second + _minute * 60 + _degree * 3600;
        }
        public override string ToString()
        {
            //return _degree + (char)176 + " " + _minute + "\' " + _second + "\"";
            return _degree + "degree  " + _minute + "\' " + _second + "\"";
        }
        #region Arithmetic Operators
        public static Angle operator +(Angle a1,Angle a2)
        {
            a1._degree += a2._degree;
            a1._minute += a2._minute;
            a1._second += a2._second;
            a1.ToAngle();
            return a1;
        }
        public static Angle operator -(Angle a1, Angle a2)
        {
            a1._degree -= a2._degree;
            a1._minute -= a2._minute;
            a1._second -= a2._second;
            a1.ToAngle();
            return a1;
        }
        #endregion
        #region Logical Operators
        public static bool operator ==(Angle a1, Angle a2)
        {
            return (a1._degree == a2._degree && a1._minute == a2._minute && a1._second == a2._second);
        }
        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1._degree == a2._degree && a1._minute == a2._minute && a1._second == a2._second);
        }
        public static bool operator >(Angle a1,Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            if (a1.ToSeconds() > a2.ToSeconds())
            {
                return true;
            }
            else return false;
        }
        public static bool operator <(Angle a1, Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            if (a1.ToSeconds() < a2.ToSeconds())
            {
                return true;
            }
            else return false;
        }
        public static bool operator >=(Angle a1, Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            if (a1.ToSeconds() >= a2.ToSeconds())
            {
                return true;
            }
            else return false;
        }
        public static bool operator <=(Angle a1, Angle a2)
        {
            a1.ToPositivAngle();
            a2.ToPositivAngle();
            if (a1.ToSeconds() <= a2.ToSeconds())
            {
                return true;
            }
            else return false;
        }
        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            Angle myAngle = new Angle(100);
            WriteLine(myAngle);
            myAngle.ToPositivAngle();
            WriteLine(myAngle);
            Angle myAngle1 = new Angle(20);
            WriteLine(myAngle1);
            myAngle1.ToPositivAngle();
            WriteLine(myAngle1);

            WriteLine("{0} + {1} = {2}", myAngle, myAngle1, myAngle + myAngle1);
            WriteLine("{0} - {1} = {2}", myAngle, myAngle1, myAngle - myAngle1);
            WriteLine();
            myAngle.ToPositivAngle();
            WriteLine(myAngle);
            myAngle1.ToPositivAngle();
            WriteLine(myAngle1);
            if (myAngle > myAngle1)
                WriteLine("myAngle > myAngle1");
            else
                if (myAngle < myAngle1)
                    WriteLine("myAngle < myAngle1");
                else WriteLine("myAngle = myAngle1");
            ReadKey();
        }
    }
}
