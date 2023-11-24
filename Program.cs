using task2;

Field myField = new Field(3);
myField.consoleFigure();
int count = 0;
Console.WriteLine("Введите фигуру, которой ходит первый игрок (x или 0): ");
string? figure = Console.ReadLine();
if (!figure.Equals("x") && !figure.Equals("0"))
{
    Console.WriteLine($"{figure} - неверная фигура. Нужно ввести x или 0");
    return;
}
while (count != 9)
{
    Console.WriteLine($"Ход {figure}");
    Console.WriteLine("Введите нормер ячейки (от 1 до 9: )");
    double position = double.Parse(Console.ReadLine());
    Console.Clear();
    myField.enterFigure(position, figure);
    bool win = myField.checkWin(position, figure);
    
    myField.consoleFigure();
    count++;
    if (win)
    {
        Console.WriteLine($"{figure} - выиграли!!!");
        break;
    }
    if (figure == "x")
        figure = "0";
    else figure = "x";
}

if (count == 9)
{
    Console.WriteLine("Победила дружба!");
}