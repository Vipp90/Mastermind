using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class Highscores
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public String toString2()
        {
            TimeSpan t = TimeSpan.FromMilliseconds(this.Score);

            string answer = string.Format("{0:D2}m:{1:D2}s:{2:D2}mili",
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            String pom1 = this.Name + "," + answer;
            return pom1;
        }

        public override bool Equals(Object ob)
        {
            String Name1 = Name;
            String Name2 = ((Highscores)ob).Name;  
            bool a = Name.Equals(Name2);
            return a;
        }
    }
}
