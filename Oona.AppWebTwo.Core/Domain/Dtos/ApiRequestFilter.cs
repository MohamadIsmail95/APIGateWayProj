using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Core.Domain.Dtos
{
    public class ApiRequestFilter
    {
        private int initPageNum;
        private int initpageSize;
        public string? SearchQuery { get; set; }
        public string? SortingField { get; set; }
        public string? SortingDir { get; set; }
        public int PageNumber { get { return initPageNum; } set { initPageNum = (value <= 0) ? initPageNum = 1 : value; } }
        public int PageSize { get { return initpageSize; } set { initpageSize = (value <= 0) ? initpageSize = 10 : value; } }

    }
}
