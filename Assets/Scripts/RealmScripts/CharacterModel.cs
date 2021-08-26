using Realms;

public class CharacterModel : RealmObject
{
    [PrimaryKey]
    public string gamerTag { get; set; }
    public int tokenCount { get; set; }
    public int enemyDefeatedCount { get; set; }
    public CharacterModel() { }
    public CharacterModel(string gamerTag, int tokenCount, int enemyDefeatedCount)
    {
        this.gamerTag = gamerTag;
        this.tokenCount = tokenCount;
        this.enemyDefeatedCount = enemyDefeatedCount;
    }
}