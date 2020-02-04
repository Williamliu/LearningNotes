using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using System;

namespace ConsoleApp3
{

    /*
    public interface ITypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source, TDestination destination, ResolutionContext context);
    }
    */
    public class IntTypeConvert : ITypeConverter<string, int>
    {
        int ITypeConverter<string, int>.Convert(string source, int destination, ResolutionContext context)
        {
            int temp = 0;
            int.TryParse(source, out temp);
            destination += 50000 + temp;
            return destination;

        }
    }
    public class DateTypeConvert : ITypeConverter<DateTime, ExpireDate>
    {
        ExpireDate ITypeConverter<DateTime, ExpireDate>.Convert(DateTime source, ExpireDate destination, ResolutionContext context)
        {
            destination = new ExpireDate();
            destination.ticks = (int)source.Ticks;
            destination.dt = source;
            return destination;
        }
    }
   
    public class ExpireDate
    {
        public ExpireDate()
        {
            this.dt = DateTime.MinValue;
        }
        public DateTime dt;
        public int ticks;
    }

public class NameResolver : IValueResolver<Employee, Manager, int>
{
    int IValueResolver<Employee, Manager, int>.Resolve(Employee source, Manager destination, int destMember, ResolutionContext context)
    {
        destMember = 1000 + destination.Levelmod;
        return destMember + 100;
    }
}

    public class LevelMemberSolver : IMemberValueResolver<Employee, Manager, string, int>
    {
        int IMemberValueResolver<Employee, Manager, string, int>.Resolve(Employee source, Manager destination, string sourceMember, int destMember, ResolutionContext context)
        {
            int temp = 0;
            int.TryParse(sourceMember, out temp);
            destMember = 6000 + destMember + temp;
            return destMember;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = 999;
            int.TryParse("dkd", out a1);
            Console.WriteLine("Try: {0}", a1);

            Func<string, string, string> func = (a, b)=> { a += "11";  return $"{a} + {b} + { a + b}"; } ;
            string res = func("hello", "world");
            Console.WriteLine("Res: {0}", res);


Mapper.Initialize(cfg =>
{
    //cfg.CreateMap<string, int>().ConvertUsing(s=> { int it = 0; int.TryParse(s, out it); return it;  });
    cfg.CreateMap<string, int>().ConvertUsing<IntTypeConvert>();
    cfg.CreateMap<DateTime, ExpireDate>().ConvertUsing<DateTypeConvert>();

    cfg.CreateMap<Guard, Teacher>(MemberList.None)
    .ForMember(dst => dst.FName, opt => opt.ResolveUsing((s,d)=> { return s.fullname + d.FName; }))
    ;
    cfg.CreateMap<Child, Student>(MemberList.None)
    ;
   
cfg.CreateMap<Employee, Manager>(MemberList.None)
.ForMember(dst=>dst.beginDate, opt=>opt.MapFrom(s=>s.startDate))
.ForMember(dst=>dst.FullName, opt=>opt.ResolveUsing( (src,dst,dstMember,context)
    =>context.Items["myname"] + " & " + context.Items["hisname"] + " : " + dstMember + " ~ " + src.firstname ))
;

    cfg.AddConditionalObjectMapper().Where((s, d) => { return d.Name.ToLower() == "manager1" &&  s.Name.ToLower() == "ee"; });
    cfg.AddMemberConfiguration().AddName<PrePostfixName>( s => s.AddStrings(p => p.DestinationPostfixes, "Model", "Mod", "Yes"));

    cfg.CreateMap<Person, Parent>(MemberList.None)
    .ReverseMap()
    .ForMember(dst=>dst.FullName, opt=>opt.MapFrom(s=>s.fullname + " Reverse"))
    ;
});
Mapper.AssertConfigurationIsValid();


Employee ee = new Employee
{
    startDate = DateTime.Now.AddDays(-10),
    title = "Good Emp",
    fullnameWay = "emp full",
    firstname = "Test First",
    lastname = "test Last",
    level = "Yes"
};
Manager mm = new Manager
{
    FullName = "Manager:Name",
    Levelmod = 88,
    Titleyes = "CEO Manager"
};
Mapper.Map<Employee, Manager>(ee, mm,   opt=> { opt.Items["myname"] = "Good Friday";
                                        opt.Items["hisname"] = "Excellent Sun"; });
var pp = mm;

            #region
            
            Guard gg = new Guard
            {
                age= "99 year",
                fullname = "Grada",
                Hornor = "Awesome",
                addr = new Address
                {
                    country = "USA",
                    state = 301,
                    city = "NewYork"
                },
                kids = new Child { name = "Grada Son1" }
            };

            Teacher tt = new Teacher
            {
                Age = "21 Year",
                FName = "Teacher Yuan",
                ct = "Beijing",
                st = "990",
                cnty = "China",
                Kids = new Student {  Name = "Teams", Score = 876, Level =303}
            };

            Teacher t1;
            t1 = Mapper.Map<Teacher>(gg);
            Mapper.Map(gg, tt);
            var temp = tt;
            
            /*
            Person[] persons = new Person[]
{
    new Person
    {
            FullName="Amanda",
            MyAddr = new Address
            {
                country = "USA",
                state = 101,
                city = "Seattle"
            }
    },
    new Person
    {
        FullName="Peter",
        MyAddr = new Address
        {
            country = "China",
            state = 201,
            city = "Shanghai"
        }
    }
};
IList<Parent> parents = new List<Parent>
{
    new Parent{level = 800 },
    new Parent{level = 801 },
    new Parent{level = 802 },
    new Parent
    {
        level = 803,
        fullname = "Tommy",
        myaddrCity = "Vancouver",
        myaddrState = 399,
        MyAddrCountry = "Canada"
    }
};
Mapper.Map<Person[], IList<Parent>>(persons, parents);
var pp = parents;
*/
            #endregion

            #region collection
            #endregion

            #region class map
            Person ps1 = new Person
            {
                FullName = "Tommy Yang",
                Amount = 268,
                Horby = "Sport SKI",
                MyAddr = new Address
                {
                    country = "USA",
                    state = 1020
                }
            };
            Parent pp1 = new Parent
            {
                fullname = "Wlilliam Liu",
                myaddrState = 888,
                myaddrCity = "Beijing"
            };
            Mapper.Map<Parent, Person>(pp1, ps1);
            var pp2 = pp1;

            #endregion


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

public class Manager
{
    public ExpireDate beginDate { get; set; }
    public string FullName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Titleyes { get; set; }
    public int Levelmod { get; set; }
}

public class Employee
{
    public DateTime startDate;
    public string fullnameWay { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string title { get; set; }
    public string level { get; set; }
}

    public class Teacher
    {
        public Teacher()
        {
            //this.Kids = new List<Student>();
        }
        public string Age { get; set; }
        public int hornor { get; set; }
        public string prize { get; set; }
        public string FName { get; set; }
        public string cnty { get; set; }
        public string st { get; set; }
        public string ct { get; set; }
        public Student Kids { get; set;}
        
        /*
        public void Add(string name, int sc, int lv)
        {
            this.Kids.Add(new Student { Name = name, Score = sc, Level = lv });
        }
        */
        
    }
    public class Guard
    {
        public Guard()
        {
           //this.kids = new List<Child>();
        }
        public string age { get; set; }
        public string fullname { get; set; }
        public string Hornor { get; set; }
        public Address addr { get; set; }
        public Child kids { get; set; }
        /*
        public void Add( string name )
        {
            this.kids.Add(new Child { name = name });
        }
        */        
    } 
    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
    }
    public class Child
    {
        public string name { get; set; }
        public int getscore { get { return 66; } }
    }
    

    public class Person
    {
        public string FullName { get; set; }
        public Address MyAddr { get; set; }
        public int Amount { get; set; }
        public string Horby { get; set; }
    }

    public class Parent
    {
        public string fullname { get; set; }
        public int level { get; set; }
        public string MyAddrCountry { get; set; }
        public int myaddrState { get; set; }
        public string myaddrCity { get; set; }
    }
    public class Address {
        public string country { get; set; }
        public int state { get; set; }
        public string city { get; set; }
    }
    

    public class User
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int Level { get; set; }
        public string courseCNAME { get; set; }
        public DateTime courseOccur { get; set; }
        public DateTime? Birthday { get; set; }

        public int GETAmount()
        {
               return 100;
        }
    }

    public class UserPro
    {
        public string fname { get; set; }
        public int level { get; set; }
        public int? age { get; set; }
        public DateTime birthday { get; set; }
        public int getamount { get; set; }
        public byte AMOUNT { get; set; }
        public Course Course { get; set; }
    }

    public class Course
    {
        public string CName { get; set; }
        public DateTime occur { get; set; }
    }


    public class Rule
    {
        public string RuleName { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Range size { get; set; }
    }
    public class RuleDto
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
    }
    public enum Range
    {
        low = 1,
        medium = 2,
        high = 3
    }

public class UserMapPF : Profile
{
        public UserMapPF() : base()
        {
            CreateMap<User, UserPro>()
            .BeforeMap((s, d) => Console.WriteLine("UserProfile Before: {0} - {1}", s.FName, d.fname))
            .AfterMap((s, d) => Console.WriteLine("UserProfile After: {0} - {1}", s.FName, d.fname));
            AddMemberConfiguration().AddName<PrePostfixName>(p=>p.AddStrings(n=>n.Prefixes, "FName")).AddName<ReplaceName>(_ =>{ _.AddReplace("A", "B").AddReplace("M", "N"); });

        }
    }
public class RuleMapPF : Profile
{
    public RuleMapPF()
    {
        CreateMap<Rule, RuleDto>()
            .BeforeMap((s, d) => Console.WriteLine("MapProfile Before: {0} - {1}", s.size, d.Size))
            .AfterMap((s, d) => Console.WriteLine("MapProfile After: {0} - {1}", s.size, d.Size));
    }
}

}
