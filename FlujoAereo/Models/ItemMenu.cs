using FlujoAereo.Enums;
using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class ItemMenu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ItemMenuType Type { get; set; }
        //public FlatPanel View { get; set; }
    }
}
