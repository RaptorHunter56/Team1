using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Steven Bown\Source\Repos\Team1\ConsoleApplication1\ConsoleApplication1\lib");
            List<string> dList = new List<string>();
            using (var db = new tempContext())
            {
                db.ClearAll();
                foreach (var file in d.GetFiles("*.lsw"))
                {
                    dList.Add($@"{file.Directory.ToString()}\{file.Name}");
                    string[] readText = File.ReadAllLines($@"{file.Directory.ToString()}\{file.Name}");
                    Console.WriteLine(file.Directory);
                    Console.WriteLine(file.Name);
                    db.LsFile.Add(new lsFile
                    {
                        Name = file.Name,
                        Path = file.Directory.ToString()
                    });
                    db.SaveChanges();
                    foreach (var ttxt in readText.Where(s => s.Contains("namespace")))
                    {
                        db.LsNameSpace.Add(new lsNameSpace
                        {
                            Name = ttxt.Replace("namespace", "").Trim(),
                            lsFileID = db.LsFile.Where(s => s.lsFileId == db.LsFile.Count()).First()
                        });
                        db.SaveChanges();
                    }
                }
                db.SaveChanges();

                //foreach (var blog in db.LsFile)
                //{
                //    Console.WriteLine(blog.Name);
                //}
            }

            string source = System.IO.File.ReadAllText(@"C:\Users\Steven Bown\Source\Repos\Team1\ConsoleApplication1\ConsoleApplication1\lib\Test01.lsw");
            Console.WriteLine(source);

            Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", "v3.5"}
                };
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

            CompilerParameters compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            //CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);
            CompilerResults results = provider.CompileAssemblyFromFile(compilerParams, dList.ToArray());

            if (results.Errors.Count != 0)
                throw new Exception("Mission failed!");

            object o = results.CompiledAssembly.CreateInstance("Foo.Bar");
            MethodInfo mi = o.GetType().GetMethod("SayHello");
            mi.Invoke(o, new object[] { "Steven" });
            MethodInfo mt = o.GetType().GetMethod("SayHello2");
            mt.Invoke(o, new object[] { "Steven" });

            

        }
    }
}
