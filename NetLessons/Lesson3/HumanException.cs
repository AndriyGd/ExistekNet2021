using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class HumanException: ApplicationException
    {
        private readonly string _message;
        private readonly Human _data;

        public HumanException(string message, Human human)
        {
            _message = message;
            _data = human;
        }

        public override string Message => $"{_message}\nName: {_data.Name}";
        //public override string Message 
        //{ 
        //    get
        //    { 
        //        return _message; 
        //    } 
        //}
    }
}
