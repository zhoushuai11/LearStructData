using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTestMode {
    internal class Program {
        static void Main() {
            var maxChildMultity = new MaxChildMultity();
            maxChildMultity.Run();
        }
    }
}

public struct TestStruct {
    public TestStruct(int setM, test setValue) {
        m = setM;
        value = setValue;
    }
    public int m;
    public test value;
}

public class test {
    private int m = 3;
}

public enum ShowEnum {
    First,
    Sceond
}
