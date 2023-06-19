using FrontlineTCG.Cards;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace FrontlineTCG.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class FrontlineTCGDbContext :
    AbpDbContext<FrontlineTCGDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<CardAbility> CardAbilities { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<UnitCard> UnitCards { get; set; }
public DbSet<CardFeedback> CardFeedbacks { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public FrontlineTCGDbContext(DbContextOptions<FrontlineTCGDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        builder.Entity<CardAbility>(b =>
        {
            b.ToTable(FrontlineTCGConsts.DbTablePrefix + "CardAbilities", FrontlineTCGConsts.DbSchema);
            b.ConfigureByConvention();

        });
        builder.Entity<Card>(b =>
        {
            b.ToTable(FrontlineTCGConsts.DbTablePrefix + "Cards", FrontlineTCGConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<CardAbility>().WithMany().HasForeignKey(c => c.Ability1).OnDelete(DeleteBehavior.SetNull);
        });
        builder.Entity<UnitCard>(b =>
        {
            b.ToTable(FrontlineTCGConsts.DbTablePrefix + "UnitCards", FrontlineTCGConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Card>().WithMany().HasForeignKey(c => c.Card).OnDelete(DeleteBehavior.Cascade);//je tehnično 1-1, ampak one with one ne dela
            b.HasOne<CardAbility>().WithMany().HasForeignKey(c => c.Ability2).OnDelete(DeleteBehavior.SetNull);
        });
        builder.Entity<CardFeedback>(b =>
        {
            b.ToTable(FrontlineTCGConsts.DbTablePrefix + "CardFeedbacks", FrontlineTCGConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Card>().WithMany().HasForeignKey(c => c.Card);
        });

   /*     builder.Entity<CardDeck>(b =>

        {
            b.ToTable(FrontlineTCGConsts.DbTablePrefix + "CardDecks", FrontlineTCGConsts.DbSchema);
            b.ConfigureByConvention();
        });*/


        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        


        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(FrontlineTCGConsts.DbTablePrefix + "YourEntities", FrontlineTCGConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
