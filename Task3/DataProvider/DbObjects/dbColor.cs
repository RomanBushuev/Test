using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper; 

namespace DataProvider.DbObjects
{
    [Table("colors")]
    public class dbColor
    {
        [Column("id_colour")]
        public int IdColur { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
