using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using System.Drawing;

Console.WriteLine("Hello, Silk.Net!");

var _options = WindowOptions.Default with
{
    Size = new Vector2D<int>(800, 600),
    Title = "Hello.Silk.Net.DrawUsage"
};

var _window = Window.Create(_options);

GL? _gl = null;

_window.Load += () =>
{
    Console.WriteLine("Window loaded!");

    var _input = _window.CreateInput();

    for (int i = 0; i < _input.Keyboards.Count; i++)
        _input.Keyboards[i].KeyDown += (keyboard, key, keyCode) =>
        {
            Console.WriteLine($"Keyboard {i} key down! Key: {key}, Key code: {keyCode}");

            if (key == Key.Escape)
                _window.Close();
        };

    _gl = _window.CreateOpenGL();

    _gl?.ClearColor(Color.CornflowerBlue);
};

_window.Update += (frameTime) =>
{
    Console.WriteLine($"Window updated! Frame time: {frameTime}");
};

_window.Render += (dateTime) =>
{
    Console.WriteLine($"Window rendered! Date time: {dateTime}");

    _gl?.Clear(ClearBufferMask.ColorBufferBit);
};

_window.Run();
