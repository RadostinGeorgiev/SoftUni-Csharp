using System.Collections;
using System.Collections.Generic;

namespace Lake
{
    public class Lake : IEnumerable<int>
    {
        private int[] _stones;

        public Lake(params int[] data)
        {
            _stones = data;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < _stones.Length; i+=2)
            {
                yield return _stones[i];
            }

            int last = _stones.Length % 2 == 0 ? _stones.Length - 1 : _stones.Length - 2;

            for (var i = last; i >= 0; i-=2)
            {
                yield return _stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}