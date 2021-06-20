using System;

namespace Cat_House
{
    class Program
    {
        static void Run()
        {
            try
            {

                Cat cat1 = new Cat("Spike", 2, 250, 8, "male");
                Cat cat2 = new Cat("Mestan", 3, 360, 15, "female");
                Cat cat4 = new Cat("pisik", 5, 568, 4, "male");
                Cat cat5 = new Cat("yaxsi pisik", 1, 100, 20, "female");
                CatHouse catHouse = new CatHouse("PET SHOP");
                catHouse.AddCat(cat1);
                catHouse.AddCat(cat2);
                CatHouse catHouse2 = new CatHouse("PET SHOP");
                catHouse2.AddCat(cat4);
                catHouse2.AddCat(cat5);
                Cat cat3 = new Cat("Bomba pisik", 4, 500, 15, "Female");
                catHouse.AddCat(cat3);
                PetShop petShop = new PetShop();
                petShop.AddCatHouse(catHouse);
                petShop.AddCatHouse(catHouse2);
                petShop.Show();
                Console.WriteLine();
                Console.WriteLine($"All Cats Price in Cat Houses: {petShop.GetCatsPriceInTheCatHouses()}");

                for (int i = 0; i < 12; i++)
                {
                    cat1.Play();
                    cat1.Eat();
                }

                Cat removedCat = catHouse.RemoveByNickName(cat3.NickName);
                removedCat.Show();
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (InvalidOperationException content)
            {
                Console.WriteLine(content);
            }
        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
