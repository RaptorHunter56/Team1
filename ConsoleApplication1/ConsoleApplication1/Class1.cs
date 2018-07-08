using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class tempContext : DbContext
    {
        public DbSet<lsFile> LsFile { get; set; }
        public DbSet<lsNameSpace> LsNameSpace { get; set; }
        public DbSet<lsClass> LsClass { get; set; }
        public DbSet<lsMethod> LsMethod { get; set; }


        public void ClearAll()
        {
            this.LsFile.Clear();
            this.Database.ExecuteSqlCommand("DBCC CHECKIDENT(lsFiles, RESEED, 0);");
            this.LsNameSpace.Clear();
            this.Database.ExecuteSqlCommand("DBCC CHECKIDENT(lsNameSpaces, RESEED, 0);");
            this.LsClass.Clear();
            this.Database.ExecuteSqlCommand("DBCC CHECKIDENT(lsClasses, RESEED, 0);");
            this.LsMethod.Clear();
            this.Database.ExecuteSqlCommand("DBCC CHECKIDENT(lsMethods, RESEED, 0);");
        }
    }

    public class lsFile
    {
        public int lsFileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<lsNameSpace> lsNameSpaces { get; set; }
    }
    public class lsNameSpace
    {
        public int lsNameSpaceId { get; set; }
        public string Name { get; set; }
        public lsFile lsFileID { get; set; }
        public List<lsClass> lsClasss { get; set; }
    }
    public class lsClass
    {
        public int lsClassId { get; set; }
        public string Name { get; set; }
        public lsNameSpace lsNameSpaceID { get; set; }
        public List<lsMethod> lsMethods { get; set; }
    }
    public class lsMethod
    {
        public int lsMethodId { get; set; }
        public string Name { get; set; }
        public lsClass lsClassID { get; set; }
    }

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
