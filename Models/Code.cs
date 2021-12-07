using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class Code
    {
        public long CodeId { get; set; }
        public string FirstColor { get; set; }
        public string SecondColor { get; set; }
        public string ThirdColor { get; set; }
        public string FourthColor{ get; set;}

        public long Game_infoId { get; set; }
        public virtual Game_info Game { get; set; }

       
        public string[] ToString2()
        {
            string[] colors= {"","","","" };
            colors[0] = FirstColor;
            colors[1] = SecondColor;
            colors[2] = ThirdColor;
            colors[3]=  FourthColor;

            return colors;
        }
    }
   }
