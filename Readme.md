# OldPhonePadApp

## ?? Description

This application simulates decoding text input on an old mobile phone keypad (like T9 input). The input uses:
- Digits `2`–`9` for letters
- `0` for space
- `*` as backspace
- `#` to end the message

## ?? Example

Input: `4433555 555666#`  
Output: `HELLO`

## ?? Features

- Supports letter cycling by repeated button presses
- Handles space-separated inputs for identical digits
- Supports `*` for deleting previous character
- Robust against malformed input

## ?? Usage

Run the application with `dotnet run`. Test cases are included in `OldPhonePadTests.cs`.

To decode a string, use:
```csharp
string output = OldPhonePad.Decode("4433555 555666#");
Console.WriteLine(output); // HELLO
