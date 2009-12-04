using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Core
{
	public class NumberSource:IEnumerable<int>
	{
		public IEnumerator<int> GetEnumerator()
		{
			return Enumerable.Range(1,100).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}