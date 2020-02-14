namespace Fliek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'22b04436-4f7f-49d2-916e-9edc109c5a77', N'admin@fliek.com', 0, N'AFZXdlwLsl6va/FL0vRofeGgfgKstmcyy8QYABtrIQi6tnopoZv6qihSSHiyJfK1oQ==', N'e22aae70-7f5a-42f7-8403-93045a48a199', NULL, 0, 0, NULL, 1, 0, N'admin@fliek.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5e178105-c264-4ef5-b31c-9552ae3d0253', N'guest@fliek.com', 0, N'ABAR8nwV1zQ7B4RB38xvVww7fuakgTM3YVN2IYZr25rRbMv8FQkZsXNQGYPDsVuv/w==', N'138384bc-f6b5-4e3f-831e-55035b75e53e', NULL, 0, 0, NULL, 1, 0, N'guest@fliek.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f7927466-6803-47c6-bf26-7907c1947150', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22b04436-4f7f-49d2-916e-9edc109c5a77', N'f7927466-6803-47c6-bf26-7907c1947150')

");
        }
        
        public override void Down()
        {
        }
    }
}
