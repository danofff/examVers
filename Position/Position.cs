using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position
{
    public enum position { manager=1, accountant,economist, system_administrator, boss }
    [Serializable]
    public class Position
    {
        private static int IdHandler { get; set; } = 1;
        public int IdPosition { get; }
        public position PositionName { get; set; }
        public double BaseSalary { get; set; }
        public int RangeNumber { get; }
        public Position()
        {
            IdPosition = IdHandler;
            IdHandler++;
            PositionName = position.manager;
            RangeNumber = (int)PositionName;
        }
        public Position(position pos):this(pos, 0.0)
        {
            IdPosition = IdHandler;
            IdHandler++;
            PositionName = pos;
            RangeNumber = (int)pos;          
        }
        public Position (position pos,double salary)
        {
            IdPosition = IdHandler;
            IdHandler++;
            PositionName = pos;
            RangeNumber = (int)pos;
            BaseSalary = salary;
        }
    }
}
