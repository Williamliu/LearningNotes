using System;
using Unity;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Unity.Resolution;
using Unity.Attributes;
using Unity.Lifetime;

namespace Unity_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
UnityContainer ucon = new UnityContainer();
ucon.RegisterType<iOperation, MySQL>("MYSQL");
ucon.RegisterType<iOperation, SQL>("MSSQL");
ucon.RegisterType<iOperation, ORA>("ORACLE");
ucon.RegisterType<iDB, DB>();

ParameterOverrides  parms = new ParameterOverrides();
parms.Add("user", "LWH");
//parms.Add("admin", "WLIU");
parms.Add("table", "Education");
parms.Add("rowno", 10);
iDB db = ucon.Resolve<iDB>(parms);
db.Update("Students");

                Console.WriteLine("\nEnd!");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err.Message}\n\nMessage: {err.StackTrace}");
            }
            Console.ReadLine();
            
        }
    }
public interface iOperation
{
    void save(string a);
}
public class MySQL : iOperation
{
    public MySQL()
    {
        Console.WriteLine("MySQL() Constructor");
    }
    public void save(string a)
    {
        Console.WriteLine($"MySQL save({a})");
    }
}

public class SQL : iOperation
{
    public string User { get; set; }
    public SQL()
    {
        this.User = "DBO";
        Console.WriteLine("SQL() Constructor");
    } 
    public SQL(string user)
    {
        this.User = user;  
        Console.WriteLine($"SQL({user}) Constructor");
    }
    public void save(string a)
    {
        Console.WriteLine($"SQL save({a}) by {this.User}");
    }
}

public class ORA : iOperation
{
    public string Admin { get; set; }
    [InjectionConstructor]
    public ORA()
    {
        this.Admin = "ORAAdmin";
        Console.WriteLine("ORA() Constructor");
    }
    [InjectionConstructor]
    public ORA(string admin)
    {
        this.Admin = admin;
        Console.WriteLine($"ORA({admin}) Constructor");
    }
    public void save(string a)
    {
        Console.WriteLine($"ORA save({a}) by {this.Admin}");
    }
}

public interface iDB
{
    bool Update(string a);
}
public class DB : iDB
{
    public iOperation dbAction { get; set; }
    public iOperation dbAction1 { get; set; }
    public iOperation dbAction2 { get; set; }
    public DB(string table, int rowno)
    {
        Console.WriteLine($"DB Constructor({table}, {rowno})");
    }
    public bool Update (string a)
    {
        this.dbAction.save(a);
        this.dbAction1.save(a + "+1");
        this.dbAction2.save(a + "+2");
        return true;
    }
    [InjectionMethod]
    public void initInject([Dependency("MYSQL")]iOperation op, [Dependency("MSSQL")]iOperation op1, [Dependency("ORACLE")]iOperation op2)
    {
        this.dbAction = op;
        this.dbAction1 = op1;
        this.dbAction2 = op2;
    }
}

}
