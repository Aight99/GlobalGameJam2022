using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class BattleManager : MonoBehaviour
{
    // Добавить реализацию взятия карт
    [SerializeField] private int timeOnTurn;
    private Enemy[] _enemies;
    private Card[] _hand;
    private Player _player;
    private StateOfWorld _world;
    private LoopState _loopState;
    private Queue<Card> _cardsQueue = new();
    private Queue<Enemy> _aliveEnemies = new();
    public ICreature Target { get; set; }

    private Card _playerCard;
    public Card PlayerCard
    {
        get => _playerCard;
        set
        {
            _playerCard = value;
            _cardsQueue.Enqueue(value);
        }
    }


    private float _timeLeft;

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        
        if (Target != null && _loopState == LoopState.Drop && Input.GetKey(KeyCode.Space))
        {
            NextTurn();
        }

        if (_loopState == LoopState.PlayerTurn && _timeLeft <= 0)
        {
            if (_cardsQueue.Count == 0)
            {
                NextTurn();
                return;
            }
            
            HandleCommand(_cardsQueue.Dequeue().Use());
            Debug.Log("Разыграна карта!");
            _timeLeft = timeOnTurn;
        }
        
        if (_loopState == LoopState.EnemyTurn && _timeLeft <= 0)
        {
            if (_aliveEnemies.Count == 0)
            {
                NextTurn();
                return;
            }
            
            HandleCommand(_aliveEnemies.Dequeue().Act());
            Debug.Log("Враг совершил преступление!");
            _timeLeft = timeOnTurn;
        }
    }

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _hand = FindObjectsOfType<Card>();
        _player = FindObjectOfType<Player>();
        _world = FindObjectOfType<StateOfWorld>();
        _loopState = LoopState.Drop;
        _timeLeft = timeOnTurn;
    }

    private bool IsVictory()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.IsAlive())
                return false;
        }

        Debug.Log("Ура победа");
        return true;
    }
    
    private void NextTurn()
    {
        if (_loopState == LoopState.Drop)
        {
            _loopState = LoopState.PlayerTurn;
        }
        else if (_loopState == LoopState.PlayerTurn)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.IsAlive())
                    _aliveEnemies.Enqueue(enemy);
            }
            
            _loopState = LoopState.EnemyTurn;
        }
        else
        {
            Debug.Log("Выберите карты!");
            _loopState = LoopState.Drop;
        }

        IsVictory();
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
}