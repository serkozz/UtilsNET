using System.Runtime.InteropServices;
using System.Globalization;

namespace UtilsNET.Input;

static partial class KeyManager
{
    [LibraryImport("user32.dll")]
    private static partial short GetAsyncKeyState(int vKey);

    [LibraryImport("user32.dll")]
    private static partial IntPtr GetKeyboardLayout(uint idThread);

    public static readonly Dictionary<int, string> KEYS = new()
    {
            { 0x01, "Left Mouse Button" },
            { 0x02, "Right Mouse Button" },
            { 0x03, "Control Break" },
            { 0x04, "Middle Mouse Button" },
            { 0x05, "X1 Mouse Button" },
            { 0x06, "X2 Mouse Button" },
            { 0x08, "Backspace" },
            { 0x09, "Tab" },
            { 0x0D, "Enter" },
            { 0x10, "Shift" },
            { 0x11, "Control" },
            { 0x12, "Alt" },
            { 0x13, "Pause" },
            { 0x14, "Caps Lock" },
            { 0x1B, "Esc" },
            { 0x20, "Space" },
            { 0x21, "Page Up" },
            { 0x22, "Page Down" },
            { 0x23, "End" },
            { 0x24, "Home" },
            { 0x25, "Left Arrow" },
            { 0x26, "Up Arrow" },
            { 0x27, "Right Arrow" },
            { 0x28, "Down Arrow" },
            { 0x2C, "Print Screen" },
            { 0x2D, "Insert" },
            { 0x2E, "Delete" },
            { 0x30, "0" },
            { 0x31, "1" },
            { 0x32, "2" },
            { 0x33, "3" },
            { 0x34, "4" },
            { 0x35, "5" },
            { 0x36, "6" },
            { 0x37, "7" },
            { 0x38, "8" },
            { 0x39, "9" },
            { 0x41, "A / Ф" },
            { 0x42, "B / И" },
            { 0x43, "C / С" },
            { 0x44, "D / В" },
            { 0x45, "E / У" },
            { 0x46, "F / А" },
            { 0x47, "G / П" },
            { 0x48, "H / Р" },
            { 0x49, "I / Ш" },
            { 0x4A, "J / О" },
            { 0x4B, "K / Л" },
            { 0x4C, "L / Д" },
            { 0x4D, "M / Ь" },
            { 0x4E, "N / Т" },
            { 0x4F, "O / Щ" },
            { 0x50, "P / З" },
            { 0x51, "Q / Й" },
            { 0x52, "R / К" },
            { 0x53, "S / Ы" },
            { 0x54, "T / Е" },
            { 0x55, "U / Г" },
            { 0x56, "V / М" },
            { 0x57, "W / Ц" },
            { 0x58, "X / Ч" },
            { 0x59, "Y / Н" },
            { 0x5A, "Z / Я" },
            { 0x5B, "Left Windows" },
            { 0x5C, "Right Windows" },
            { 0x5D, "Applications" },
            { 0x60, "Numeric Keypad 0" },
            { 0x61, "Numeric Keypad 1" },
            { 0x62, "Numeric Keypad 2" },
            { 0x63, "Numeric Keypad 3" },
            { 0x64, "Numeric Keypad 4" },
            { 0x65, "Numeric Keypad 5" },
            { 0x66, "Numeric Keypad 6" },
            { 0x67, "Numeric Keypad 7" },
            { 0x68, "Numeric Keypad 8" },
            { 0x69, "Numeric Keypad 9" },
            { 0x6A, "Numeric Keypad *" },
            { 0x6B, "Numeric Keypad +" },
            { 0x6C, "Numeric Keypad ," },
            { 0x6D, "Numeric Keypad -" },
            { 0x6E, "Numeric Keypad ." },
            { 0x6F, "Numeric Keypad /" },
            { 0x70, "F1" },
            { 0x71, "F2" },
            { 0x72, "F3" },
            { 0x73, "F4" },
            { 0x74, "F5" },
            { 0x75, "F6" },
            { 0x76, "F7" },
            { 0x77, "F8" },
            { 0x78, "F9" },
            { 0x79, "F10" },
            { 0x7A, "F11" },
            { 0x7B, "F12" },
            { 0x7C, "F13" },
            { 0x7D, "F14" },
            { 0x7E, "F15" },
            { 0x7F, "F16" },
            { 0x80, "F17" },
            { 0x81, "F18" },
            { 0x82, "F19" },
            { 0x83, "F20" },
            { 0x84, "F21" },
            { 0x85, "F22" },
            { 0x86, "F23" },
            { 0x87, "F24" },
            { 0x90, "Num Lock" },
            { 0x91, "Scroll Lock" },
            { 0xA0, "Left Shift" },
            { 0xA1, "Right Shift" },
            { 0xA2, "Left Control" },
            { 0xA3, "Right Control" },
            { 0xA4, "Left Alt" },
            { 0xA5, "Right Alt" },
            { 0xA6, "Browser Back" },
            { 0xA7, "Browser Forward" },
            { 0xA8, "Browser Refresh" },
            { 0xA9, "Browser Stop" },
            { 0xAA, "Browser Search" },
            { 0xAB, "Browser Favorites" },
            { 0xAC, "Browser Home" },
            { 0xAD, "Volume Mute" },
            { 0xAE, "Volume Down" },
            { 0xAF, "Volume Up" },
            { 0xB0, "Next Track" },
            { 0xB1, "Previous Track" },
            { 0xB2, "Stop" },
            { 0xB3, "Play/Pause" },
            { 0xB4, "Mail" },
            { 0xB5, "Select Media" },
            { 0xB6, "Launch App 1" },
            { 0xB7, "Launch App 2" },
            { 0xB8, "Select Computer" },
            { 0xB9, "My Computer" },
            { 0xC0, "Left Mouse Button" },
            { 0xC1, "Right Mouse Button" },
            { 0xC2, "Middle Mouse Button" },
            // Дополнительные клавиши можно добавлять по аналогии
        };

    /// <summary>
    /// Получает состояние клавиш на клавиатуре и вызывает переданный делегат для каждой нажатой клавиши.
    /// Метод проверяет состояния клавиш с заданным интервалом и вызывает обработчик для каждой клавиши, 
    /// которая была нажата в текущий цикл.
    /// </summary>
    /// <param name="onButtonPressed">
    /// Делегат, который вызывается для каждой клавиши, которая была нажата. Параметры делегата: 
    /// VKCode - виртуальный код клавиши, KeyName - строковое представление клавиши.
    /// </param>
    /// <param name="measuringIntervalMs">
    /// Интервал в миллисекундах, определяющий частоту проверки состояния клавиш.
    /// </param>
    public static void MonitorKeyboardState(Action<(int VKCode, string KeyName)> onButtonPressed, int measuringIntervalMs = 16)
    {
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                // Проверяем состояние клавиши
                if (GetAsyncKeyState(i) != 0)
                {
                    if (KEYS.TryGetValue(i, out string? value))
                    {
                        onButtonPressed((i, value));
                    }
                    else
                    {
                        onButtonPressed((i, "UNKNOWN"));
                    }
                }
            }
            Thread.Sleep(measuringIntervalMs);
        }
    }

    /// <summary>
    /// Отслеживает нажатие клавиш на клавиатуре, вызывая переданный делегат для каждой клавиши, 
    /// которая была нажата, но игнорируя повторные нажатия до тех пор, пока клавиша не будет отпущена.
    /// Метод проверяет состояние клавиш с заданным интервалом и обрабатывает только те клавиши, которые были впервые нажаты.
    /// </summary>
    /// <param name="onButtonPressed">
    /// Делегат, который вызывается для каждой клавиши, которая была нажата. Параметры делегата: 
    /// VKCode - виртуальный код клавиши, KeyName - строковое представление клавиши.
    /// </param>
    /// <param name="measuringIntervalMs">
    /// Интервал в миллисекундах, определяющий частоту проверки состояния клавиш.
    /// </param>
    public static void MonitorUniqueKeyboardState(Action<(int VKCode, string KeyName)> onButtonPressed, int measuringIntervalMs = 16)
    {
        HashSet<int> PressedKeys = [];

        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                bool isKeyPressed = GetAsyncKeyState(i) != 0;

                // Если клавиша нажата и ранее не была обработана
                if (isKeyPressed && !PressedKeys.Contains(i))
                {
                    // Обрабатываем нажатие клавиши
                    if (KEYS.TryGetValue(i, out string? value))
                    {
                        onButtonPressed((i, value));
                    }
                    else
                    {
                        onButtonPressed((i, "UNKNOWN"));
                    }

                    // Добавляем клавишу в список обработанных
                    PressedKeys.Add(i);
                }
                // Если клавиша отпущена, убираем её из списка
                else if (!isKeyPressed && PressedKeys.Contains(i))
                {
                    PressedKeys.Remove(i);
                }
            }

            Thread.Sleep(measuringIntervalMs); // Пауза для уменьшения нагрузки на процессор
        }
    }

    /// <summary>
    /// Получает информацию о текущем раскладе клавиатуры для текущего потока, включая культуру (язык и страну).
    /// </summary>
    /// <returns>Объект <see cref="CultureInfo"/>, который содержит информацию о текущем раскладе клавиатуры.</returns>
    public static CultureInfo GetCurrentKeyboardLayoutCulture()
    {
        IntPtr layout = GetKeyboardLayout(0); // 0 для текущего потока
        uint layoutId = (uint)(long)layout & 0xFFFFFFFF;
        var culture = new CultureInfo((int)(layoutId & 0xFFFF));
        return culture;
    }
}