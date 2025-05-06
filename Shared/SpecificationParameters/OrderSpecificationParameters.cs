using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.SpecificationParameters
{
    public class OrderSpecificationParameters
    {
        const int MAXPAGESIZE = 10;
        const int DEFAULTPAGESIZE = 5;
        const int DEFAULTPAGEINDEX = 1;
        public string? Search { get; set; }

        private int _pageSize = DEFAULTPAGESIZE;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value;
        }
        public int PageIndex { get; set; } = DEFAULTPAGEINDEX;
    }

}
