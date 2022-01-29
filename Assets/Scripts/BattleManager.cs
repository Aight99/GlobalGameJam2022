using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private Enemy[] _enemies;
    private Card[] _hand;
    private Player _player;
    public ICreature Target { get; set; }
    public Card PlayerCard { get; set; }
    
    // Кароче, надо сделать так, чтобы все Use() и Act() в MakeTurn() возвращали комманду, которую 
    // уже обрабатывает (меняет StateOfWorld и здоровье существам) сам BattleManager
    //
    // Но пока что эти методы должны возвращать только урон, который накладывается на врага/игрока
    
    
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _hand = FindObjectsOfType<Card>();
        _player = FindObjectOfType<Player>();
    }

    public void MakeTurn()
    {
        Target.TakeDamage(PlayerCard.Use());
        foreach (var enemy in _enemies)
        {
            _player.TakeDamage(enemy.Act()); // Hack
        }
    }

    private float _timeLeft = 2;
    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _timeLeft <= 0)
        {
            MakeTurn();
            _timeLeft = 2;
        }
    }
}