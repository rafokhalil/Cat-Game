using System;
namespace Cat_House
{
    public class PetShop
    {
        public CatHouse[] CatHouses { get; private set; } = default;
        public int CatHouseCount { get; set; } = default;
        public void AddCatHouse(in CatHouse addedCatHouse)
        {
            if (addedCatHouse != null)
            {
                CatHouse[] temp = new CatHouse[++CatHouseCount];

                if (CatHouses != null)
                    CatHouses.CopyTo(temp, 0);

                temp[CatHouseCount - 1] = addedCatHouse;
                CatHouses = temp;
            }
        }
        public int GetCatsPriceInTheCatHouses()
        {
            int allCatsPriceInTheCatHouses = 0;
            if (CatHouses != null)
            {
                foreach (var catHouse in CatHouses)
                    allCatsPriceInTheCatHouses += catHouse.GetCatsPriceInTheCatHouse();
            }
            return allCatsPriceInTheCatHouses;
        }
        public void Show()
        {
            for (int i = 0; i < CatHouseCount; i++)
            {
                CatHouses[i].Show();
            }
            Console.ResetColor();
        }
    }
}