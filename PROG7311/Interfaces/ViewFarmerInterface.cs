using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7311.Interfaces
{
    internal interface ViewFarmerInterface
    {
        void filterProductTypes();
        string sqlSelector(string filterType, string filterFarmerName, string filterStartDate, string filterEndDate, bool typeFilter, bool nameFilter, bool startFilter, bool endFilter);
    }
}
