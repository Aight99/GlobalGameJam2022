using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Добавить реализацию взятия карт
    
    private Enemy[] _enemies;
    private Card[] _hand;
    private Player _player;
    private StateOfWorld _world;
    public ICreature Target { get; set; }
    public Card PlayerCard { get; set; }

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _hand = FindObjectsOfType<Card>();
        _player = FindObjectOfType<Player>();
        _world = FindObjectOfType<StateOfWorld>();
    }

    public void MakeTurn() // Должна быть очередь выброса
    {
        HandleCommand(PlayerCard.Use()); // Всего одна карта игрока, печалька

        foreach (var enemy in _enemies)
        {
            if (enemy.IsAlive())
                HandleCommand(enemy.Act());
        }
    }
    
    private void HandleCommand(Command command) // Вроде как надо обработать свап в процессе хода
    {
        if (command.isWorldSwap)
        {
            _world.Swap();
        }

        if (command.isTakeCards)
        {
            // Пожалуйста имплементируйте
        }

        if (command.disasterPoints > 0)
        {
            _world.AddDisaster(command.disasterPoints);
        }
        
        if (command.isForPlayer)
        {
            _player.TakeDamage(command.damage);
        }

        if (command.isForTarget)
        {
            Target.TakeDamage(command.damage);
        }
        
        if (command.isForAllEnemies)
        {
            foreach (var enemy in _enemies)
            {
                enemy.TakeDamage(command.damage);
            }
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