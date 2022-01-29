public struct Command
{
    public int damage;
    public int disasterPoints;
    public bool isForPlayer;
    public bool isForTarget;
    public bool isForAllEnemies;
    public bool isWorldSwap;
    public bool isTakeCards;

    // Карты
    public Command(int damage, int disasterPoints, bool isForTarget, bool isWorldSwap, bool isTakeCards)
    {
        this.damage = damage;
        this.disasterPoints = disasterPoints;
        isForPlayer = false;
        
        if (isForTarget)
        {
            this.isForTarget = true;
            isForAllEnemies = false;
        }
        else
        {
            this.isForTarget = false;
            isForAllEnemies = true;
        }
        
        this.isWorldSwap = isWorldSwap;
        this.isTakeCards = isTakeCards;
    }
    
    // Враги
    public Command(int damage, int disasterPoints, bool isForPlayer, bool isForAllEnemies)
    {
        this.damage = damage;
        this.disasterPoints = disasterPoints;
        this.isForPlayer = isForPlayer;
        this.isForAllEnemies = isForAllEnemies;
        isTakeCards = false;
        isForTarget = false;
        isWorldSwap = false;
    }
    
    // Полный
    public Command(int damage, int disasterPoints, bool isForPlayer, bool isForTarget, bool isForAllEnemies, bool isWorldSwap, bool isTakeCards)
    {
        this.damage = damage;
        this.disasterPoints = disasterPoints;
        this.isForPlayer = isForPlayer;
        this.isForTarget = isForTarget;
        this.isForAllEnemies = isForAllEnemies;
        this.isWorldSwap = isWorldSwap;
        this.isTakeCards = isTakeCards;
    }
    
    
    
    // public Command(int disasterPoints, bool isWorldSwap, bool isTakeCards)
    // {
    //     this.isTakeCards = isTakeCards;
    //     this.disasterPoints = disasterPoints;
    //     this.isWorldSwap = isWorldSwap;
    //     damage = 0; 
    //     isForPlayer = false;
    //     isForTarget = false;
    //     isForAllEnemies = false;
    // }

    // public Command(int damage, int disasterPoints, bool isForPlayer, bool isForTarget, bool isForAllEnemies)
    // {
    //     this.damage = damage;
    //     this.disasterPoints = disasterPoints;
    //     this.isForPlayer = isForPlayer;
    //     this.isForTarget = isForTarget;
    //     this.isForAllEnemies = isForAllEnemies;
    //     isWorldSwap = false;
    //     isTakeCards = false;
    // }
}