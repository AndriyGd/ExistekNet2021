using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class MyCollection : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 123;
            yield return 563;
            yield return 328;
            yield return 6278;
            yield return 9345;
            yield return 8246;
            yield return 02399;
            yield return -55353;
            yield return -321323;
            yield return -343464;
            yield return 303929;
            yield return -2343243;
            yield return 82929;
            yield return -34335;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
