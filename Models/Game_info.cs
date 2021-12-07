using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class Game_info
    {
        public long Game_infoId { get; set; }
        public virtual Code Code { get; set; }
        public string SessionID { get; set; }
        public string Player_name { get; set; }
        public string Mode { get; set; }
        public DateTime date { get; set; }
    }
}
