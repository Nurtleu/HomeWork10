using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork10
{
    public class Player
    {
        public List<Card> maps;
        public Player()
        {
            maps = new List<Card>();
        }
        public void Show()
        {
            int cardNum = 0;
            foreach(var map in maps)
            {
                WriteLine("Номер карты игрока: {0}", cardNum);
                WriteLine(map.Garb);
                WriteLine(map.Type);
                ++cardNum;
            }
        }   
    }
}
