using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

internal class Configuration{   
  public string Key { get; set; }   
  public string Value { get; set; }
}

internal class ConfigurationDbContext : DbContext{   
   
   private EFConfigurationOptionsBuilder Builder { get; }  
   public ConfigurationDbContext(EFConfigurationOptionsBuilder options) : base(options.DbContextOptions.Options)    {
        Builder = options;
    }    
    public DbSet<Configuration> Configurations { get; set; }
}


public class EFConfigurationOptionsBuilder
{
    public EFConfigurationOptionsBuilder() { }
    public string TableName { get; set; }
    public DbContextOptionsBuilder DbContextOptions { get; set; }
}

public class EFConfigurationProvider : ConfigurationProvider { 
    Action<EFConfigurationOptionsBuilder> OptionsAction { get; }  
    public EFConfigurationProvider(Action<EFConfigurationOptionsBuilder> optionsAction)    {
        OptionsAction = optionsAction;
    }    
    public override void Load() {      
        var builder = new EFConfigurationOptionsBuilder();
        OptionsAction(builder);      
        using (var ctx = new ConfigurationDbContext(builder))
        {
            ctx.Database.EnsureCreated();
            Data = ctx.Configurations.ToDictionary(t => t.Key, t => t.Value);
        }
    }
}


public class EFConfigurationSource : IConfigurationSource{  
    private readonly Action<EFConfigurationOptionsBuilder> _optionsAction;    
    public EFConfigurationSource(Action<EFConfigurationOptionsBuilder> optionsAction)    
    {
        _optionsAction = optionsAction;
    }   
  

    public IConfigurationProvider Build(IConfigurationBuilder builder)    
    {     
        return new EFConfigurationProvider(_optionsAction);
    }
}

public static class EFConfigurationExtensions{   
 
public static IConfigurationBuilder AddEntityFramework(this IConfigurationBuilder builder, Action<EFConfigurationOptionsBuilder> setup)    {      
    return builder.Add(new EFConfigurationSource(setup));
    }
}

/*
var builder = new ConfigurationBuilder()
.AddEntityFramework(options =>
{
    options.TableName = "configs";        
    options.DbContextOptions.UseSqlite("Filename=config.db");
});

Configuration = builder.Build();
*/