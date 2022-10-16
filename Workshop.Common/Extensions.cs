using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Workshop.Common
{
    public static class Extensions
    {
        public static string Serialize<T>(this T @object, bool preserveObjectReferences = false)
        {
            var serializer = new DataContractSerializer(typeof(T), new DataContractSerializerSettings { 
                PreserveObjectReferences = preserveObjectReferences,
            });
            
            using var ms = new MemoryStream();

            serializer.WriteObject(ms, @object);
            ms.Position = 0;
            
            using var reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }

        public static T? Deserialize<T>(this string xml)
        {   
            var serializer = new DataContractSerializer(typeof(T));

            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var obj = serializer.ReadObject(ms);
            if(obj != null)
            {
                return (T)obj;
            }

            return default;
        }

        public static void Print(this object @object, int depth = 0,TextWriter writer = null)
        {
            ObjectDumper.Write(@object,depth,writer ?? Console.Out);            
        }

        public static void PrintDebug(this object @object, int depth = 0)
        {
            ObjectDumper.Write(@object, depth,new  TextWriterDebug());
        }

        public static string FormatMethodCall(this MethodBase method, params object[] parameters)
        {
            return string.Format("{0}({1})", method.Name,
                                 string.Join(",", method.GetParameters().Zip(parameters, (p, v) => p.Name + ":" + v)));
        }
        public static void PrintMethodCall(this MethodBase method, params object[] parameters)
        {
            Console.WriteLine(FormatMethodCall(method, parameters));
        }

        #region TextWriterDebug
        
        //http://stackoverflow.com/questions/2779746/is-there-a-textwriter-interface-to-the-system-diagnostics-debug-class
        class TextWriterDebug : TextWriter
        {
            
            public override Encoding Encoding
            {
                get { return System.Text.Encoding.Default; }
            }

            //public override System.IFormatProvider FormatProvider
            //{ get; }
            //public override string NewLine
            //{ get; set; }

            public override void Close()
            {
                System.Diagnostics.Debug.Close();
                base.Close();
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
            }

            public override void Flush()
            {
                Debug.Flush();
                base.Flush();
            }

            public override void Write(bool value)
            {
                Debug.Write(value);
            }

            public override void Write(char value)
            {
                Debug.Write(value);
            }

            public override void Write(char[]? buffer)
            {
                Debug.Write(buffer);
            }

            public override void Write(decimal value)
            {
                Debug.Write(value);
            }

            public override void Write(double value)
            {
                Debug.Write(value);
            }

            public override void Write(float value)
            {
                Debug.Write(value);
            }

            public override void Write(int value)
            {
                Debug.Write(value);
            }

            public override void Write(long value)
            {
                Debug.Write(value);
            }

            public override void Write(object? value)
            {
                Debug.Write(value);
            }

            public override void Write(string? value)
            {
                Debug.Write(value);
            }

            public override void Write(uint value)
            {
                Debug.Write(value);
            }

            public override void Write(ulong value)
            {
                Debug.Write(value);
            }

            public override void Write(string format, object? arg0)
            {
                Debug.Write(string.Format(format, arg0));
            }

            public override void Write(string format, params object?[] arg)
            {
                Debug.Write(string.Format(format, arg));
            }

            public override void Write(char[] buffer, int index, int count)
            {
                Debug.Write(new string(buffer, index, count));
            }

            public override void Write(string format, object? arg0, object? arg1)
            {
                Debug.Write(string.Format(format, arg0, arg1));
            }

            public override void Write(string format, object? arg0, object? arg1, object? arg2)
            {
                Debug.Write(string.Format(format, arg0, arg1, arg2));
            }

            public override void WriteLine()
            {
                Debug.WriteLine(string.Empty);
            }

            public override void WriteLine(bool value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(char value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(char[]? buffer)
            {
                Debug.WriteLine(buffer);
            }

            public override void WriteLine(decimal value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(double value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(float value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(int value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(long value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(object? value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(string? value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(uint value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(ulong value)
            {
                Debug.WriteLine(value);
            }

            public override void WriteLine(string format, object? arg0)
            {
                Debug.WriteLine(string.Format(format, arg0));
            }

            public override void WriteLine(string format, params object?[] arg)
            {
                Debug.WriteLine(string.Format(format, arg));
            }

            public override void WriteLine(char[] buffer, int index, int count)
            {
                string x = new string(buffer, index, count);
                Debug.WriteLine(x);

            }

            public override void WriteLine(string format, object? arg0, object? arg1)
            {
                Debug.WriteLine(string.Format(format, arg0, arg1));
            }

            public override void WriteLine(string format, object? arg0, object? arg1, object? arg2)
            {
                Debug.WriteLine(string.Format(format, arg0, arg1, arg2));
            }
        }

        #endregion  
    }
}
