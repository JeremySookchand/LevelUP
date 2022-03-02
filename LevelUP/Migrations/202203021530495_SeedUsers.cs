namespace LevelUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b578e2a-dba4-4cf1-ac42-674f8accc6a8', N'guest@levelup.com', 0, N'AGgdiGmuo0UBNnNkOIHx2mQWMl2KPDW7g9r4WhENLAAKXZF/UsOn//5daJZc4nUA1A==', N'3f8430ca-e448-4ca2-a1f9-c78f57665092', NULL, 0, 0, NULL, 1, 0, N'guest@levelup.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4626d69-a659-4db9-844e-79629f7649a6', N'j.alexander193@gmail.com', 0, N'ACyC1r2OxNMup3ODMpuM2m6iwksFZXwKbSmkmjBFPGV7ZgskJTKtjCeU7sgOkPPVBw==', N'6bd29ea8-7ff2-4932-b091-705f0ee1ef88', NULL, 0, 0, NULL, 1, 0, N'j.alexander193@gmail.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4626d69-a659-4db9-844e-79629f7649a6', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')
");
        }
        
        public override void Down()
        {
        }
    }
}
