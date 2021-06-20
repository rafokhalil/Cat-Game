using System;
using System.Threading;
using System.Text;
namespace Cat_House
{
    public class Cat
    {
        public string NickName { get; set; } = String.Empty;
        private int _age;
        private int _price;
        private string _gender;
        private int _mealQuantity;
        public int Energy { get; private set; } = 100;
        private int _mealQuantityOfCatToday = default;
        public Cat(in string nickName, in int age, in int mealQuantity, in int price, in string gender)
        {
            NickName = nickName;
            Age = age;
            MealQuantity = mealQuantity;
            Price = price;
            Gender = gender;
            _mealQuantityOfCatToday = (MealQuantity * 10) / 100;
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Age must be more than 0.");
                _age = value;
            }
        }
        public int MealQuantity
        {
            get
            {
                return _mealQuantity;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Meal Quantity must be more than 0.");
                _mealQuantity = value;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Price must be more than 0.");
                _price = value;
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value.Trim().ToLower() != "male" && value.Trim().ToLower() != "female")
                    throw new InvalidOperationException("Gender must be \"Male\" or \"Female\"");
                _gender = value;
            }
        }
        public void Eat()
        {
            if (Energy == 0)
            {
                Console.WriteLine("Your energy is gone. Go sleep. You can't eat without energy.");
                return;
            }
            IncrementPrice(ref _price);
            IncrementMealQuantity(ref _mealQuantityOfCatToday);
            const int eatingEnergy = 20;
            if (Energy + eatingEnergy <= 100)
                Energy += eatingEnergy;
        }
        public void Play()
        {
            const int playEnergy = 10;
            if (Energy - playEnergy >= 0)
            {
                Energy -= playEnergy;
                Show();
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine("You're out of energy. Go to bed to collect energy!.");
                Show();
                Sleep();
                Thread.Sleep(500);
                Console.Clear();
            }
        }
        public void Sleep()
        {
            const int sleepEnergy = 20;
            if (Energy + sleepEnergy <= 100)
                Console.WriteLine($"{Energy += sleepEnergy}");
            IncrementPrice(ref _price);
            Show();
            Thread.Sleep(800);
        }
        static public void IncrementPrice(ref int price) => price += (price * 10) / 100;
        static public void IncrementMealQuantity(ref int mealQuantity) => mealQuantity += (mealQuantity * 85) / 100;
        public void Show()
        {
            if (Energy == 0)
            {
                Sleep();
                Console.Clear();
            }
            string trimVersionOfGender = Gender.Trim();
            StringBuilder gender = new StringBuilder();
            gender.Append(char.ToUpper(trimVersionOfGender[0]))
                  .Append(trimVersionOfGender.Substring(1));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cat's name : {NickName}");
            Console.WriteLine($"Cat's age : {Age}");
            Console.WriteLine($"Cat's meal quantity : {MealQuantity} gr");
            Console.WriteLine($"Cat's price : {Price} $");
            Console.WriteLine($"Cat's gender : {gender}");
            Console.WriteLine($"Cat's energy : {Energy}");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Cat's meal quantity for today : {_mealQuantityOfCatToday} gr");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}