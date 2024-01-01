public interface ICardBattleInputPort
{
    void SelectCard(Card card);
    void PlayCard(Card card);
    void ManageDeck(DeckAction action);
}
