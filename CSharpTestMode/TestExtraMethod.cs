using System;

public static class TestExtraMethod {
    public static void Cmd(this int value) {
        Console.WriteLine(value);
    }
}