﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpecificationsParameters
    {

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public string? Sort {  get; set; }

        public string? Search { get; set; }

        private int _PageIndex = 1;
        private int _PageSize = 18;

        public int PageSize
        {

            get { return _PageSize; }

            set { _PageSize = value; }

        }

        public int PageIndex
        {
            get { return _PageIndex; }

            set { _PageIndex = value; }

        }

    }
}
