using System;
using System.Collections.Generic;
using System.IO;

class PindoramaArena
{
    string[] attackMoves = { "Capoeira Kick", "Spear Throw", "Defend" };
    string[] monsterMoves = { "Bite", "Claw Strike", "Defend" };

    Dictionary<int, string> turns = new Dictionary<int, string>();
    List<string> battleLog = new List<string>();

    Random sorteio = new Random();

    public int CalculateDamage(FolkFighter attacker, string move)
    {
        int damage = attacker.AttackPower;

        if (move == "Capoeira Kick")
        {
            damage = damage + 10;
        }
        else if (move == "Spear Throw")
        {
            damage = damage + 30;
        }
        else if (move == "Bite")
        {
            damage = damage + 20;
        }
        else if (move == "Claw Strike")
        {
            damage = damage + 15;
        }
        else if (move == "Defend")
        {
            damage = 0;
        }

        if (attacker.Health <= 20)
        {
            damage = damage * 2;
        }


        return damage;
    }

    public void SimulateTurn(int turn, FolkFighter attacker, FolkFighter defender, string move)
    {
        turns.Add(turn, move);

        if (move == "Defend")
        {
            string lineDefend = $"\nTurno {turn}: {attacker.Name} se defendeu!";
            battleLog.Add(lineDefend);
            Console.WriteLine(lineDefend);
            return;
        }

        int damage = CalculateDamage(attacker, move);
        defender.ReceiveDamage(damage);

        string line = $"\nTurno {turn}: {attacker.Name} usou {move} e causou {damage} de dano em {defender.Name}. Vida restante: {defender.Health}";
        battleLog.Add(line);
        Console.WriteLine(line);
    }

    public void RunBattle(FolkFighter warrior, FolkFighter monster)
    {
        Console.WriteLine($"\n⚔️  {warrior.Name} vs {monster.Name}  ⚔️\n");

        int turn = 1;
        bool turnWarrior = true;

        while (warrior.StayAlive() && monster.StayAlive())
        {
            if (turnWarrior)
            {
                string move = ChooseMovement();
                SimulateTurn(turn, warrior, monster, move);
            }
            else
            {
                int index = sorteio.Next(0, monsterMoves.Length);
                string move = monsterMoves[index];
                SimulateTurn(turn, monster, warrior, move);
            }

            if (!warrior.StayAlive())
            {
                string result = $"\n>>> {monster.Name} venceu a batalha! <<<";
                battleLog.Add(result);
                Console.WriteLine(result);
                break;
            }
            else if (!monster.StayAlive())
            {
                string result = $"\n>>> {warrior.Name} venceu a batalha! <<<";
                battleLog.Add(result);
                Console.WriteLine(result);
                break;
            }

            turnWarrior = !turnWarrior;
            turn = turn + 1;
        }
    }

    string ChooseMovement()
    {
        Console.WriteLine("\nEscolha seu golpe:");
        Console.WriteLine("\n1 - Capoeira Kick");
        Console.WriteLine("2 - Spear Throw");
        Console.WriteLine("3 - Defend");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            return attackMoves[0];
        }
        else if (choice == "2")
        {
            return attackMoves[1];
        }
        else if (choice == "3")
        {
            return attackMoves[2];
        }
        else
        {
            Console.WriteLine("\nOpção inválida! Usando Capoeira Kick.");
            return attackMoves[0];
        }
    }

    public void ShowLog()
    {
        Console.WriteLine("\n📝 Log da Batalha 📝");
        foreach (string line in battleLog)
        {
            Console.WriteLine(line);
        }
    }
    public void ExportBattleLogTxt()
    {
        File.WriteAllLines("BattleLog.txt", battleLog);
        Console.WriteLine("\nLog exportado para BattleLog.txt!");
    }
}