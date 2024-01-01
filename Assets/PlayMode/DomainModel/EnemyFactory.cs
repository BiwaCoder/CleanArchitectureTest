using System.Collections.Generic;

public class EnemyFactory 
{
    public List<Character> CreateEnemy()
    {
        List<Character> enemies = new List<Character>();
        
        //3体エネミーを作り、リストに追加する
        for (int i = 0; i < 3; i++)
        {
            Character enemy = CreateEnemyInstance();
            enemies.Add(enemy);
        }
    
        return enemies;
    }

    public　Character CreateEnemyInstance()
    {
        Character enemy = new Character();
        enemy.Name = "スライム";
        enemy.MaxHp = 10;
        enemy.Hp = 10;
        enemy.Atk = 2;
        enemy.Def = 1;
        enemy.Speed = 1;

        return enemy;
    }
}
