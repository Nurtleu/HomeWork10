using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    public class NumberOfPlayer<T> where T:Player,new()
    {
        public List<Card> maps;
        public T[] games;
        public int Size
        {
            get; set;
        }
        public NumberOfPlayer()
        {
            Size = 4;
            games = new T[Size];
            for (int i = 0; i < Size; ++i)
            {
                games[i] = new T();
            }
        }
        public IEnumerable<T> GetData()
        {
            for (int i = 0; i < Size; ++i)
            {
                yield return games[i];
            }
        }
        public T this[int i]
        {
            get
            {
                return games[i];
            }
            set
            {
                games[i] = value;
            }
        }
        public void show()
        {
            Array.Resize(ref games, Size);
            for (int i = 1; i < Size; ++i)
            {
                games[i] = new T();
            }
        }

        public void Delete(int index)
        {
            for (int i = index; i < Size; ++i)
            {
                if (i == Size - 1)
                {

                }
                else
                {
                    games[i] = games[i + 1];
                }
            }
            Array.Resize(ref games, --Size);
        }
    }
}
