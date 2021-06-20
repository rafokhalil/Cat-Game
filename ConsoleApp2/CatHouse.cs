using System;
using System.Collections.Generic;
namespace Cat_House
{
    public class CatHouse
    {
        public string Name { get; set; } = String.Empty;
        public Cat[] Cats { get; private set; } = default;
        public int CatCount { get; private set; } = default;
        public CatHouse(in string name)
        {
            Name = name;
        }
        public void AddCat(in Cat addedCat)
        {
            if (addedCat != null)
            {
                Cat[] temp = new Cat[++CatCount];

                if (Cats != null)
                {
                    Cats.CopyTo(temp, 0);
                }
                temp[temp.Length - 1] = addedCat;
                Cats = temp;
            }
        }
        private int FindNickNameByIndex(in string nickName)
        {
            if (!String.IsNullOrWhiteSpace(nickName))
            {
                for (int i = 0; i < Cats.Length; i++)
                {
                    if (Cats[i].NickName == nickName)
                        return i;
                }
            }
            throw new KeyNotFoundException("NickName didn't exist in the Cat House.");
        }
        private void Remove(in int index)
        {
            if (index >= 0 && CatCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("REMOVED");
                Cat[] newCats = new Cat[--CatCount];
                if (index > 0)
                    Array.Copy(Cats, 0, newCats, 0, index);
                if (index < Cats.Length - 1)
                    Array.Copy(Cats, index + 1, newCats, index, Cats.Length - index - 1);
                Cats = newCats;
            }
        }
        public Cat RemoveByNickName(in string nickName)
        {
            try
            {
                int index = FindNickNameByIndex(nickName);
                Cat cat = Cats[index];
                Remove(index);
                return cat;
            }
            catch (KeyNotFoundException note)
            {
                Console.WriteLine(note);
            }
            return null;
        }
        public int GetCatsPriceInTheCatHouse()
        {
            int allCatsPrice = 0;
            if (Cats != null)
            {
                foreach (var cat in Cats)
                    allCatsPrice += cat.Price;
            }
            return allCatsPrice;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(new string(' ', (Console.WindowWidth - "Name of Pet house :".Length) / 2));
            Console.WriteLine($" Name of Pet house : {Name}");
            Console.WriteLine();
            Console.Write(new string('=', Console.WindowWidth));
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < CatCount; i++)
                Cats[i].Show();
        }
    }
}