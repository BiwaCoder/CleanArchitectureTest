public class Card
{
    public string Name { get; set; }
    public int Cost { get; set; }
    // その他のカード特有のプロパティ: 攻撃力、防御力、特殊効果など

    public Card(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }

    // このカードの効果を発動するメソッド
    public void ActivateEffect()
    {
        // カードの効果を実装
    }
}
