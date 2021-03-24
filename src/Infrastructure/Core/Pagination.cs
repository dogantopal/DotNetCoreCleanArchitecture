using System.Collections.Generic;

namespace Infrastructure.Core
{
    public class Pagination<T> where T : class
    {
        public Pagination(int skip, int take, int count, IReadOnlyList<T> data)
        {
            Skip = skip;
            Take = take;
            Count = count;
            Data = data;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
