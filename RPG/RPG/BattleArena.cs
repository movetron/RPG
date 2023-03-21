using RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class BattleArena
    {
        public Enemy Enemy { get; set; }
        public Hero Hero { get; set; }
        public Item Item { get; set; }
        BackPack BackPack { get; set; }


        public BattleArena(Enemy enemy, Hero hero, BackPack backPack)
        {
            Enemy = enemy;
            Hero = hero;
            BackPack = backPack;
        }



        public void Battle()
        {
            Random rand = new Random();
            int Chance;
            var Enemy = new Enemy("Грязный Гарри",  15, 125, 13);

            Console.WriteLine($"Выберите оружие из рюкзака {BackPack.Show}");
            BackPack.Show();
            Console.WriteLine("введите 1/2/3 в зависимости от того что вы хотите взять");
            int s3 = Convert.ToInt32(Console.ReadLine());
            double HeroDamage = 0;
            double hp = Hero.Hp;
            if (s3 == 1)
            {
                if (BackPack.ItemNameGet(0) == "Аптечка")
                {
                    hp = hp + 50;
                    BackPack.DeleteItem(0);
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (s3 == 2)
            {
                if (BackPack.ItemNameGet(1) == "Аптечка")
                {
                    hp = hp + 50;
                    BackPack.DeleteItem(1);
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (s3 == 3)
            {
                if (BackPack.ItemNameGet(2) == "Аптечка")
                {
                    hp = hp + 50;
                    BackPack.DeleteItem(2);
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (s3 == 4)
            {
                if (BackPack.ItemNameGet(3) == "Аптечка")
                {
                    hp = hp + 50;
                    BackPack.DeleteItem(3);
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (s3 == 5)
            {
                if (BackPack.ItemNameGet(4) == "Аптечка")
                {
                    hp = hp + 50;
                    BackPack.DeleteItem(4);
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            Console.WriteLine("Теперь вы готовы к битве со своими противниками. Противника завут " + Enemy.Name);
            string[] step = { "Нападение", "Защита" };

            bool step1 = false;
        restart:

            do
            {

                Console.WriteLine("Противник нападает, выберите действие 1 - защититься, 2 - напасть в ответ");
                int change = Convert.ToInt32(Console.ReadLine());
                if (change == 1 && rand.Next(0, 1001) < 801)
                {
                    Console.WriteLine("Вы смогли защититься от атаки, с этих пор атаковать уже будете вы");
                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    step1 = true;

                }
                else if (change == 1 && rand.Next(0, 1001) >= 801)
                {
                    Console.WriteLine("Вы не смогли защититься, вам нанесли урон");
                    hp -= Enemy.Damage;
                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли(");
                    }
                    else
                    {


                        goto restart;
                    }

                }
                else if (change == 2 && rand.Next(0, 1001) > 801)
                {
                    Console.WriteLine("Вы смогли ударить в ответ и попали!");
                    Enemy.Hp -= Enemy.Damage;

                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли(");
                    }
                    else
                    {


                        step1 = true;
                    }
                }
                else if (change == 2 && rand.Next(0, 1001) <= 801)
                {
                    Console.WriteLine("Ваша попытка атаковать закончилась провалом. Попробуйте в следущий раз, может быть вам повезет");
                    hp -= Enemy.Damage;
                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли(");
                    }
                    else
                    {


                        goto restart;
                    }
                }
            } while (step1 == false);

        start:

            do
            {

                Console.WriteLine("");
                Console.WriteLine("1 - нападайте");
                int change = Convert.ToInt32(Console.ReadLine());
                if (change == 1 && rand.Next(0, 1001) > 201 && rand.Next(0, 1001) > 501)
                {
                    Console.WriteLine("Враг не смог увернуться, вы попали!");
                    Enemy.Hp -= Enemy.Damage;

                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                        break;
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли("); break;
                    }
                    else
                    {


                        goto start;
                    }

                }
                else if (change == 1 && rand.Next(0, 1001) <= 201 && rand.Next(0, 1001) >= 501)
                {
                    Console.WriteLine("Вы промахнулись, враг увернулся. Попробуйте ещё раз");

                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1); break;
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли("); break;
                    }
                    else
                    {


                        step1 = false;
                        goto restart;
                    }
                }
                else if (change == 1 && rand.Next(0, 1001) >200 && rand.Next(0, 1001) < 500) 
                {
                    Console.WriteLine("Враг решил атаковать в ответ!");
                    Console.WriteLine("Продолжить атаку или защититься? 1 / 2");
                    int s4 = Convert.ToInt32(Console.ReadLine());
                    if (s4 == 1 && rand.Next(0, 100) < 80)
                    {
                        Enemy.Hp -= Enemy.Damage;
                        Console.WriteLine("Враг не смог вас атаковать в ответ и потерпел поражение");
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                        if (Enemy.Hp < 0)
                        {
                            Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1); break;
                        }
                        else if (hp < 0)
                        {
                            Console.WriteLine("Вы проиграли("); break;
                        }
                        else
                        {


                            goto start;
                        }
                    }


                    else if (s4 == 1 && rand.Next(0, 1001) >= 800)
                    {
                        Console.WriteLine("Враг успешно атаковал в ответ");
                        hp -= Enemy.Damage;
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                        if (hp < 0)
                        {
                            Console.WriteLine("Вы проиграли("); break;
                        }
                        else
                        {


                            step1 = false;
                            goto restart;
                        }
                    }
                    else if (s4 == 2 && rand.Next(0, 1001) < 800)
                    {
                        Console.WriteLine("Вы успешно защитились");
                        goto start;
                    }
                    else if (s4 == 2 && rand.Next(0, 1001) >=800)
                    {
                        Console.WriteLine("Вы не смогли защититься от ответной атаки враг");
                        hp -= Enemy.Damage;
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");

                        if (hp < 0)
                        {
                            Console.WriteLine("Вы проиграли("); break;
                        }
                        else
                        {


                            step1 = false;
                            goto restart;
                        }
                    }
                }
                else if (change == 1 && rand.Next(0, 1000) <= 200 && rand.Next(0, 1001) <= 500)
                {
                    Console.WriteLine("Враг решил атаковать в ответ, но промахнулся и получает урон");
                    Enemy.Hp -= Enemy.Damage;
                  
                    Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1); break;
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли("); break;
                    }
                    else
                    {


                        goto start;
                    }//<20&&<50    >=20&&<=50  <=20&&>=50  >=20>=50
                }
                } while (step1 == true);



        }

    }
}