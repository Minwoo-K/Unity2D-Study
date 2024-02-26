using UnityEngine;

public enum ItemType { Random=-1, Coin=0, Invincibility, Projectile, HPPotion, Star, Count }

public static class Define
{
    public static readonly int      MaxLevel    = 10;
    public static readonly int      StarCount   = 3;

    public static readonly string   CurrentLevel  = "CURRENT_LEVEL";
    public static readonly string   LevelUnlocked = "LEVEL_UNLOCKED";
    public static readonly string   Stars         = "STARS";
    public static readonly string   Coins         = "COINCOUNT";

    public static (bool, bool[]) LoadLevelData(int level)
    {
        // If locked, return 0. If unlocked, return 1
        bool isUnlocked = PlayerPrefs.GetInt($"{level}{LevelUnlocked}", 0 ) == 1 ? true : false;

        bool[] starsEarned = new bool[StarCount];

        for ( int index = 0; index < StarCount; index ++ )
        {
            starsEarned[index] = PlayerPrefs.GetInt($"{level}{Stars}{index}", 0) == 1 ? true : false;
        }

        return (isUnlocked, starsEarned);
    }

    public static void SaveUponLevelComplete(int level, bool[] starsEarned, int coins)
    {
        PlayerPrefs.SetInt($"{Coins}", coins);

        //PlayerPrefs.SetInt($"{CurrentLevel}{Stars}")

        if ( level+1 <= MaxLevel )
        {
            PlayerPrefs.SetInt($"{level+1}{LevelUnlocked}", 1);
        }

        for ( int i = 0; i < starsEarned.Length; i++ )
        {
            PlayerPrefs.SetInt($"{level}{Stars}{i}", starsEarned[i] == true ? 1 : 0);
        }
    }
}
