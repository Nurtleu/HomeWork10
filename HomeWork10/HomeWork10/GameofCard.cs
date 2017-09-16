using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork10
{
    public class GameofCard
    {
        
        NumberOfCard<Card> maps;
        NumberOfPlayer<Player> players;
        private Random rnd;
        public int countPlayer = 4;
        public GameofCard()
        {
            rnd = new Random();
        }
        public void Distribut()
        {
            int cardNum;
            foreach (var player in players.GetData())
            {
                players.Size = countPlayer;
                for (int i = 0; i < maps.Size / players.Size; ++i)
                {
                    do
                    {
                        cardNum = rnd.Next(0, 36);
                    } while (player.maps.Contains(maps[cardNum]) && maps.DistributOfCard.Contains(maps[cardNum]));
                    player.maps.Add(maps[cardNum]);
                    maps.Distribut(maps[cardNum]);
                }
                ++countPlayer;
            }
        }
        public void Contains()
        {
            int i = 0;
            foreach (var card in maps.GetData(maps.Size))
            {
                do
                {
                    card.Garb = (CardGarb)rnd.Next(0, 4);
                    card.Type = (CardType)rnd.Next(0, 9);
                } while (maps.Contain(card.Garb, card.Type, i));
                ++i;
            }
        }
        public void Play()
        {
            WriteLine("Введите количество игрок:");
            players.Size = Int32.Parse(ReadLine());
            players.show();
            Contains();
            Distribut();
            foreach (var player in players.GetData())
            {
                WriteLine("Карта игрока под номером {0}", player.maps);
                player.ShowCard();
            }
            WriteLine("Нажмите чтобы продолжить ...");
            ReadLine();
            Clear();

            do
            {
                Round();
                for (int i = 0; i < players.Size; ++i)
                {
                    if (players[i].maps.Count == 0)
                    {
                        players.Delete(i);
                    }

                }
                for (int i = 0; i < players.Size; ++i)
                {
                    if (players[i].maps.Count == 36)
                    {
                        WriteLine("Выиграл игрок номером {0}", players[i].maps);
                    }
                }
                WriteLine("Нажмите чтобы продолжить ...");
                ReadLine();
                Clear();
            } while (players.Size > 1);
        }
        public void Round()
        {
            List<Card> PlayCards = new List<Card>();
            Card highCard = players[0].maps[0];
            int i, highCardIndex = 0;
            for (i = 0; i < players.Size; ++i)
            {
                PlayCards.Add(players[i].maps[players[i].maps.Count - 1]);
                if (players[i].maps[players[i].maps.Count - 1].Type > highCard.Type)
                {
                    highCard = players[i].maps[players[i].maps.Count - 1];
                    highCardIndex = i;

                }
                players[i].maps.RemoveAt(players[i].maps.Count - 1);

            }
            foreach (var maps in PlayCards)
            {
                players[highCardIndex].maps.Add(maps);
            }
            WriteLine("Карта выигрывшего игрока:");
            players[highCardIndex].Show();
        }
    }
}