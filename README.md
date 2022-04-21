# MonoSerialWrite

This small C# program can be used to perform rudimentary fuzzing towards Serial interfaces.

Basicly a selection can be made of what characters will be sent and how many.

Currently included character sets are:
- 0 - Random small letters
- 1 - Random capital letters
- 2 - Random numbers
- 3 - Random special characters
- 4 - small + capital
- 5 - small + capital + numbers
- 6 - small + capital + numbers + special
- 7 - small + capital + numbers + special + extended
- 8 - single character (A) x times
- 9 - single random character x times

The following Serial port settings are hardcoded at the moment to:
- Parity None
- DataBits 8
- StopBits 2

BaudRate selection is asked during runtime
