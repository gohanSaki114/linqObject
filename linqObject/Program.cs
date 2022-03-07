using System;
using System.Collections;

namespace linqObject
{
    public class mainclass
    {
        List<Fruit> fruits = new List<Fruit>
            {
                new Fruit{ Id = "f1", Name = "Apple" , Color = Color.Red, Price = 23.0,},
                new Fruit{ Id = "f2", Name = "Bannana" , Color = Color.Yellow, Price = 10.0,},
                new Fruit{ Id = "f3", Name = "Pineapple" , Color = Color.Yellow, Price = 55.0,},
                new Fruit{ Id = "f4", Name = "Cherry" , Color = Color.Red, Price = 40.0,},
                new Fruit{ Id = "f5", Name = "Watermelon" , Color = Color.Green, Price = 28.0,},
                new Fruit{ Id = "f6", Name = "Strawberry" , Color = Color.Red, Price = 33.0,},

            };
        public enum Color
        { 
        Red,Green,Yellow
        }
        public class Fruit
        { 
        public string Id { get; set; }
            public Color Color { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public static void Main(string[] args)
        {
           
            mainclass clas = new mainclass();   
            clas.getOrderedFruitsInDescending(clas.fruits);
            clas.getOrderedFruitsInAscending(clas.fruits);
            clas.getRedandGreenFruits(clas.fruits);
            clas.getCheapestFruit(clas.fruits);
            clas.getMostExpensiveFruit(clas.fruits);
            clas.getBudgetFruit(clas.fruits);
            clas.getRedFruitsCount(clas.fruits);
            clas.getFruitsWithColor(clas.fruits);
        }

        private void getFruitsWithColor(List<Fruit> fruits)
        {
            var resultset = from fruit in fruits
                            group fruit by fruit.Color into fruitcolor
                             select fruitcolor;
            Console.WriteLine("Fruits with color");
            foreach (var Group in resultset)
            {
                Console.WriteLine(("GroupID = " + Group.Key));
                foreach (var cx in Group)
                {
                    Console.WriteLine(cx.Name);
                }
            }
        }

        private void getRedFruitsCount(List<Fruit> fruits)
        {
            var resultset = (from fruit in fruits
                            where fruit.Color == Color.Red
                            select fruit).ToList().Count;
           Console.WriteLine(resultset);
        }

        private void getBudgetFruit(List<Fruit> fruits)
        {
            int budgetFruit = 40;
            var resultset = from fruit in fruits
                            where fruit.Price <= budgetFruit
                            select fruit;
            Console.WriteLine("in budget fruits");
            foreach (var fruit in resultset)
            {
                Console.WriteLine(fruit.Name);

            }
            Console.WriteLine("");

        }

        private void getMostExpensiveFruit(List<Fruit> fruits)
        {
            int expensive = 35;
            var resultset = from fruit in fruits 
                            where fruit.Price >= expensive
                            select fruit;
            Console.WriteLine("Most Expensive fruits");
            foreach (var fruit in resultset)
            {
                Console.WriteLine(fruit.Name);

            }
            Console.WriteLine("");
        }

        private void getCheapestFruit(List<Fruit> fruits)
        {
            int mybudget = 11;
            var resultset = from fruit in fruits
                            where fruit.Price <= mybudget
                            select fruit;
            Console.WriteLine("Cheapest fruits");
            foreach (Fruit fruit in resultset)
            { 
            Console.WriteLine(fruit.Name);
            }
            Console.WriteLine("");
        }

        private void getRedandGreenFruits(List<Fruit> fruits)
        {
            var resultset = from fruit in fruits
                            where fruit.Color == Color.Red || fruit.Color == Color.Green
                            select fruit;
            Console.WriteLine("Red and Green Frits"+"\n");
            foreach (var res in resultset)
            { 
            Console.WriteLine(res.Name); 
            }
            Console.WriteLine("");
        }

        private void getOrderedFruitsInAscending(List<Fruit> fruits)
        {
            var cursor = from fruit in fruits
                         orderby fruit.Name ascending
                         select fruit;
            foreach (var fruit in cursor)
            { 
            Console.WriteLine(fruit.Name);  
            }
            Console.WriteLine("");
        }

        private void getOrderedFruitsInDescending(List<Fruit> fruits)
        {
          var reslutset = from fruit in fruits
                                    orderby fruit.Name descending
                                    select fruit;

            foreach (var res in reslutset)
            { 
            Console.WriteLine(res.Name);
            }
            Console.WriteLine("");
        }

    }
}