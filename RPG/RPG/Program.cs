using RPG;

int a = 3;
if (a > 3)
{
    Console.WriteLine(" ");
}else if (a < 3)
{
    Console.WriteLine(" ");
}
BackPack backPack = new(3);
backPack.Looting(1);
backPack.Looting(1);

Hero hero = new("Герой", 10, 100);
Enemy enemy = new("Грязный Гарри", 15, 125, 13);
BattleArena arena = new(enemy, hero, backPack);
arena.Battle();
arena.Battle();