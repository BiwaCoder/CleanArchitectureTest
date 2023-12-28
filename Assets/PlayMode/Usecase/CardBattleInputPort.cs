public interface CardBattleInputPort
{
    void SelectCard(Card card);
    void PlayCard(Card card);
    void ManageDeck(DeckAction action);
}
