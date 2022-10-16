using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace Workshop.Common
{
    public class UnitTestRunner
    {
        public static Type UnitTestAttributeType = typeof (TestClassAttribute);
        public static Type UnitTestMethodAttributeType = typeof(TestMethodAttribute);

        public static void Start(Assembly assembly)
        {
            var methods =
                (
                    from t in assembly.GetTypes()
                    orderby t.Name
                    where Attribute.IsDefined(t, UnitTestAttributeType)
                    from m in t.GetMethods()
                    where Attribute.IsDefined(m, UnitTestMethodAttributeType)                    
                    select m
                ).ToArray();


            while (true)
            {
                bool debugMode = false;
                int index = 0;

                Console.WriteLine();
                foreach (var methodInfo in methods)
                    Console.WriteLine("{0,-3} - {1}.{2}", index++, methodInfo.DeclaringType.Name, methodInfo.Name);
                Console.WriteLine("Podaj numer metody (oraz ! jesli chcesz debugowac), 'cls' aby wyczyscic, Enter aby zakonczyc : ");

                var line = Console.ReadLine();

                if (line == "" || line == null)
                    return;

                if (line == "cls")
                    Console.Clear();
                else
                {
                    if (line.Contains('!'))
                    {
                        line = line.Replace("!", "");
                        debugMode = true;
                    }

                    int number;
                    if (int.TryParse(line, out number) && number >= 0 && number < methods.Length)
                    {
                        try
                        {
                            var method = methods[number];
                            if (debugMode)
                            {
                                Debugger.Break();
                            }
                            method.Invoke(Activator.CreateInstance(method.DeclaringType),new object[0]);
                        }
                        catch (TargetInvocationException exception)
                        {
                            Exception? innerException = exception.InnerException;
                            if (innerException != null)
                            {
                                Console.WriteLine("Exception: " + innerException.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}