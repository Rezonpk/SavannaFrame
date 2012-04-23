using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannaFrame.Classes
{
    /// <summary>
    /// Class Domain present Domain in FraimeClot  or Production
    /// </summary>
    class Domain
    {
        // имя и id домена
        public string Name { get; set; }
        public int DomainId { get; set; }
        // список значений домена
        public List<DomainValue> DomainValues;
        
        // контруктоор
        public Domain()
        {
            DomainValues = new List<DomainValue>();
        }
    }

    class DomainValue
    {
        // имя значение
        public string ValueName { get; set; }
        // id значения 
        public int ValueId { get; set; }
    }
}
