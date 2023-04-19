using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

Console.WriteLine("Hello, Silk.Net!");

var options = WindowOptions.Default with
{
    Size = new Vector2D<int>(800, 600),
    Title = "My first Silk.NET application!"
};

var window = Window.Create(options);

window.Load += () =>
{
    Console.WriteLine("Window loaded!");

    var input = window.CreateInput();

    for (int i = 0; i < input.Keyboards.Count; i++)
        input.Keyboards[i].KeyDown += (keyboard, key, keyCode) =>
        {
            Console.WriteLine($"Keyboard {i} key down! Key: {key}, Key code: {keyCode}");

            if (key == Key.Escape)
                window.Close();
        };
};

window.Update += (frameTime) =>
{
    Console.WriteLine($"Window updated! Frame time: {frameTime}");
};

window.Render += (dateTime) =>
{
    Console.WriteLine($"Window rendered! Date time: {dateTime}");
};

window.Run();
