using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction : BattleActionInterface
{
    public List<BattleResult> GoNextTurn(Character player, Character enemy,CharacterDialogue playerDialogue,CharacterDialogue enemyDialogue)
    {
        List<BattleResult> battleResults = new List<BattleResult>();

        var playerAttackResult = Attack(player, enemy);
        playerAttackResult.DamageMessage = $"{player.Name} attacks! {enemy.Name} takes {playerAttackResult.damage} damage.";
        playerAttackResult.HpStatusMessage = $"{player.Name} HP: {player.Hp}, {enemy.Name} HP: {enemy.Hp} {playerDialogue.AttackDialogue}";
        
        if (enemy.Hp <= 0)
        {
            Debug.Log($"{enemy.Name} is defeated!");
            playerAttackResult.DefeatedMessage = $"{enemy.Name} is defeated!";
            battleResults.Add(playerAttackResult);
        }
        else{
            battleResults.Add(playerAttackResult);
            var enemyAttackResult = Attack(enemy, player);
            enemyAttackResult.DamageMessage = $"{enemy.Name} attacks! {player.Name} takes {enemyAttackResult.damage} damage.";  
            enemyAttackResult.HpStatusMessage = $"{player.Name} HP: {player.Hp}, {enemy.Name} HP: {enemy.Hp} {enemyDialogue.AttackDialogue}";
      
            if (player.Hp <= 0)
            {
                enemyAttackResult.DefeatedMessage = $"{enemy.Name} is defeated!";
            }
            battleResults.Add(enemyAttackResult);
        }
        return battleResults;
    }

    //攻撃する
    public BattleResult Attack(Character attacker, Character defender)
    {
        //攻撃力から防御力を引いた値をダメージとする
        int damage = attacker.Atk - defender.Def;
        //ダメージが0以下の場合は1とする
        if (damage <= 0)
        {
            damage = 1;
        }
        //ダメージを受ける
        defender.Hp -= damage;

        return new BattleResult
        {
            damage = damage,
            attacker = attacker,
            defender = defender
        };
    }

}
