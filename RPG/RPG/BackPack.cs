using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class BackPack
    {
        private readonly Item[] items;
        public int maxWeight { get; set; }


        public BackPack(int Freespace)
        {
            items = new Item[Freespace];
            maxWeight = Freespace + 100;
            for (int i = 0; i < Freespace; i++)
            {
                var Item = new Item("0", 0, 0);
                items[i] = Item;
            }
        }
        public static string[] Loot = new string[3]{"Граната","Звёздный меч","Аптечка"};

        public int count = 0;
        public void Add(Item item)
        {
            int j = GetWeigth();
            int k = GetSpace();
            Console.WriteLine($"Общий вес = {j}, свободного места - {k}");
            if (j < maxWeight && k > 0 && count < items.Length)
            {
                items[count] = item;
                count++;
                Console.WriteLine("Предмет у вас в рюкзаке.");
            }
            else
            {
                Console.WriteLine("Перевес.");
            }
        }

        public int GetWeigth()
        {
            int result = 0;
            for (int i = 0; i < items.Length; i++)
            {
                result += items[i].Weigth;
            }
            return result;
        }
        public int GetSpace()
        {
            int Freespace = items.Length;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Weigth != 0)
                {
                    Freespace--;
                }
                else
                {
                    continue;
                }

            }
            return Freespace;
        }
        public void Looting(int j)
        {
            if (j == 1)
            {
                Random rand = new();
                var Item = new Item(Loot[rand.Next(0, 3)], 0, 0);


                if (Item.Name == "Граната")
                {
                    Item.Weigth = 3;
                    Item.Damage = 10;

                }
                else if (Item.Name == "Звёздный меч")
                {
                    Item.Weigth = 2;
                    Item.Damage = 20;

                }
                else if (Item.Name == "Аптечка")
                {
                    Item.Weigth = 2;
                    Item.Damage = 0;

                }
               

            start:
                Console.WriteLine();
                Console.Write($"Вы подобрали с земли ресурсы: ");
                Console.Write($"{Item.Name}", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"Что вы с ним сделаете?");
                Console.WriteLine("1 - Посмотреть характеристки | 2 - Взять | 3 - Выбросить | 4 - Проверить рюкзак");
                Console.Write("Ответ: ");
                int answer = int.Parse(Console.ReadLine());

                if (answer == 1)
                {
                    Console.WriteLine();
                    Console.Write($"Вы изучаете предмет и понимаете, что его урон равен ");

                    Console.Write($" {Item.Damage}, ", Console.ForegroundColor = ConsoleColor.Yellow);
                    if (Item.Damage == 0)
                    {
                        Console.WriteLine("Ура, это аптечка!");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"а вес - {Item.Weigth}.");
                    Console.WriteLine();
                    goto start;
                }
                else if (answer == 2)
                {
                    Add(Item);
                }
                else if (answer == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Вы выбрасываете предмет.");
                }
                else if (answer == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Предмет/ Вес / Урон");
                    Console.WriteLine();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].Name == "0" && items[i].Weigth == 0 && items[i].Damage == 0)
                        {
                            Console.WriteLine("Пустой слот");
                        }
                        else if (items[i].Name == "Граната")
                        {

                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                        else if (items[i].Name == "Звёздный меч")
                        {

                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                        else if (items[i].Name == "Аптечка")
                        {

                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                      
                    }
                    goto start;
                }
            }
            else if (j == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Вы падаете на землю и теряете сознание");
                Console.WriteLine();
                Console.WriteLine("...");
                Console.WriteLine();


                Console.WriteLine("Вы очнулись на том же месте и понимаете, что виш");
                Console.WriteLine("Что ж, ничего не поделать..");
            }

        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine($"Предмет/ Вес / Цена");
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name == "0" && items[i].Weigth == 0 && items[i].Damage == 0)
                {
                    Console.WriteLine("Пустой слот");
                }
                else
                {
                    Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                }
            }

        }
        public double ItemGet(int j)
        {
            return items[j].Damage;


        }
        public string ItemNameGet(int j)
        {
            return items[j].Name;
        }
        public void DeleteItem(int j)
        {
            items[j].Weigth = 0;
            items[j].Damage = 0;
            items[j].Name = "0";
        }

    }
}