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
        #endregion
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

        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            Angle myAngle = new Angle(60,10);
            WriteLine(myAngle);
            Angle myAngle1 = new Angle(10,20);
            WriteLine(myAngle1);

            WriteLine("{0} + {1} = {2}", myAngle, myAngle1, myAngle + myAngle1);
            WriteLine("{0} - {1} = {2}", myAngle, myAngle1, myAngle - myAngle1);

            ReadKey();
        }
    }
}
