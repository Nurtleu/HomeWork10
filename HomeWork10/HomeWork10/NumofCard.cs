using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    public class NumberOfCard<T>where T:Card,new()
    {
        public NumberOfCard<T>card;
        public List<T> DistributOfCard;
        public const int countCard = 36;
        private T[] maps;

        public NumberOfCard()
        {
            DistributOfCard = new List<T>();
            maps = new T[countCard];
            for (int i = 0; i < countCard; i++)
            {
                card[i] = new T();
            }
        }
        public T this[int i]
        {
            get
            {
                return card[i];
            }
            set
            {
                card[i] = value;
            }
        }
        public IEnumerable<T> GetData(int max)
        {
            for (int i = 0; i < max; ++i)
            {
                yield return card[i];
            }
        }

        
        public bool Contain(CardGarb Suit, CardType Type, int index)
        {
            for (int i = 0; i < countCard; i++)
            {
                if (i == index)
                {
                    continue;
                }
                if (card[i] == null)
                {
                    return false;
                }
                if (card[i].Garb == Suit && card[i].Type == Type)
                {
                    return true;
                }
            }
            return false;
        }
        public int Size
        {
            get
            {
                return countCard;
            }
        }
        public void Distribut(T card)
        {
            DistributOfCard.Add(card);
        }
    }
}
