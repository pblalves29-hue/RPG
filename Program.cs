Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Folclore não se limita à história contada ao redor da fogueira. Com a subida da lua e do fechamento da mata, o que sobra é a luta pela sobrevivência. Aqui, na Pindorama Arena, os mitos com os quais você está familiarizado não se tratam apenas de personagens folclóricos, mas de predadores que competem por um pedaço de território. Não há regras, não há negociações e não há arrependimento. Você já entrou no território deles e agora só há duas opções: ou você consegue dominar o monstro ou você acaba fazendo parte da floresta.");
Console.Write("\nDigite o nome do seu guerreiro: ");
string warriorName = Console.ReadLine();

Console.WriteLine("\nEscolha seu inimigo: \r\n\r\n1 - Lobisomem 🐺 \n2 - Mula Sem Cabeça 🐴🔥");
string chooseEnemy = Console.ReadLine();

FolkFighter warrior = new FolkFighter(warriorName, 110, 20);
FolkFighter monster;

if (chooseEnemy == "1")
{
    monster = new FolkFighter("Lobisomem", 100, 18);
}
else if (chooseEnemy == "2")
{
    monster = new FolkFighter("Mula Sem Cabeça", 130, 22);
}
else
{
    Console.WriteLine("Opção inválida! Lobisomem escolhido.");
    monster = new FolkFighter("Lobisomem", 100, 18);
}

PindoramaArena arena = new PindoramaArena();

arena.RunBattle(warrior, monster);
arena.ShowLog();
arena.ExportBattleLogTxt();

Console.WriteLine("\nFim da batalha!");