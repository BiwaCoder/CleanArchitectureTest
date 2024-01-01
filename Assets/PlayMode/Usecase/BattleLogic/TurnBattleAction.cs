public class TurnBattleAction
{
    public ActionType Type { get; private set; }
    public Character Target { get; private set; }
    public Skill UsedSkill { get; private set; }
    public Item UsedItem { get; private set; }

    // コンストラクタでアクションタイプと必要な情報を設定
    private TurnBattleAction(ActionType type, Character target = null, Skill skill = null, Item item = null)
    {
        Type = type;
        Target = target;
        UsedSkill = skill;
        UsedItem = item;
    }

    // 静的ファクトリーメソッド
    public static TurnBattleAction Attack(Character target)
    {
        return new TurnBattleAction(ActionType.Attack, target);
    }

    public static TurnBattleAction Defend()
    {
        return new TurnBattleAction(ActionType.Defend);
    }

    public static TurnBattleAction UseSkill(Skill skill, Character target)
    {
        return new TurnBattleAction(ActionType.UseSkill, target, skill);
    }

    public static TurnBattleAction UseItem(Item item)
    {
        return new TurnBattleAction(ActionType.UseItem, null, null, item);
    }
}

public enum ActionType
{
    Attack,
    Defend,
    UseSkill,
    UseItem
}
