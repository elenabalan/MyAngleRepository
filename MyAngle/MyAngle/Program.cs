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
        public void ToAngle ()
        {
            //if (_degree > 0)
            //{
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
            //}
            //else
            //{
            //    //int a= 360 * 60 * 60 - Math.Abs(_degree * 3600 + _minute * 60 +_second);
            //    if (_second <= -60)
            //    {
            //        _minute += _second / 60;
            //        _second = _second % 60;
            //    }
            //    if (_minute <= 60)
            //    {
            //        _degree += _minute / 60;
            //        _minute = _minute % 60;
            //    }
            //    if (_degree <= 360)
            //        _degree = _degree - 360 * (_degree / 360);
            //}

        }
        #endregion
        public override string ToString()
        {
            //return _degree + (char)176 + " " + _minute + "\' " + _second + "\"";
            return _degree + "degree  " + _minute + "\' " + _second + "\"";
        }
        #region Arithmetic Operators

        #endregion
        #region Logical Operators

        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            Angle myAngle = new Angle(370, 66, 64);
            WriteLine(myAngle);
            Angle myAngle1 = new Angle(-370);

            WriteLine(myAngle1);


            ReadKey();
        }
    }
}
