namespace Notechest.Migrations
{
    using Notechest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Notechest.Models.NotechestDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Notechest.Models.NotechestDBContext context)
        {
            // Organizations.
            context.Organizations.AddOrUpdate(
                o => o.Name,
                new Organization
                {
                    ID = 1,
                    Name = "Making Sense",
                    CreatedOn = DateTime.Now
                }
            );

            // Projects.
            context.Projects.AddOrUpdate(
                p => p.Name,
                new Project
                {
                    ID = 1,
                    Name = "Doppler",
                    OrganizationID = 1,   
                    CreatedOn = DateTime.Now
                },
                new Project
                {
                    ID = 2,
                    Name = "Lander",
                    OrganizationID = 1,   
                    CreatedOn = DateTime.Now
                }
            );

            // Notes.
            context.Notes.AddOrUpdate(
                n => n.Title,
                new Note
                {
                    OrganizationID = 1,
                    Title = "Guidelines for new makingsensers",
                    Value = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras vestibulum sem quis lacus mattis, non mollis risus rhoncus. In sit amet imperdiet velit, eget feugiat nisi. Phasellus vel rutrum elit. Ut eu nibh nulla. Donec interdum aliquet gravida. Aenean pulvinar augue sed lectus faucibus luctus. Phasellus feugiat id lacus eu feugiat. Suspendisse ut arcu tempus, suscipit diam ut, pellentesque massa. Maecenas ac cursus elit.",
                    Tags = "guidelines, help",
                    CreatedOn = DateTime.Now
                },
                new Note
                {
                    OrganizationID = 1,
                    Title = "UX breakfasts",
                    Value = "Fusce convallis velit urna, quis sagittis dolor mollis vitae. Nam aliquam auctor neque, eget condimentum massa mattis ac. In adipiscing velit tincidunt, volutpat nibh quis, laoreet augue. Mauris id magna posuere, pellentesque eros quis, egestas felis. Mauris commodo nisi quis risus aliquam, sit amet posuere est accumsan.",
                    Tags = "UX, guidelines",
                    CreatedOn = DateTime.Now
                },
                new Note
                {
                    ProjectID = 1,
                    Title = "QA enviroments",
                    Value = "Pellentesque laoreet pulvinar leo, quis dignissim est fringilla id. Mauris bibendum tempus dui at tempor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Pellentesque vestibulum, ipsum non scelerisque laoreet, lorem erat aliquam diam, vitae pellentesque augue odio at velit. Sed at mi nulla. Suspendisse tincidunt mauris vitae mi dapibus, non molestie tellus tincidunt. Nulla et tristique mi, eu vehicula diam. Nullam rhoncus magna quis felis accumsan scelerisque. Sed lacinia massa pretium sem fermentum, at dignissim urna tempus. In sit amet tortor vitae quam condimentum mollis consequat ac lectus. Morbi eget orci diam.",
                    Tags = "enviroments, QA",
                    CreatedOn = DateTime.Now
                },
                new Note
                {
                    ProjectID = 2,
                    Title = "Setup for development",
                    Value = "Morbi turpis dui, congue sed auctor eget, tincidunt id erat. Nullam auctor pulvinar faucibus. Praesent ac bibendum erat, eget condimentum eros. Vestibulum nec lectus dui. Pellentesque gravida nibh dapibus, porttitor sapien vel, ornare lectus. Aliquam sollicitudin eleifend eleifend. Aliquam et diam urna. Nulla sed tincidunt diam. Sed eu dictum ligula, non sollicitudin leo. Proin a tristique erat. Nam nec vestibulum lacus. Proin sed justo turpis. Integer lacinia mollis eleifend. Cras tempor malesuada metus ut malesuada. Morbi non nisi urna. Vivamus a fermentum erat. Proin cursus elit eu lorem hendrerit iaculis. Duis sem augue, dictum ut laoreet ac, malesuada nec nisi. Nunc pulvinar commodo euismod. Vivamus at ultrices felis. Suspendisse volutpat risus eu euismod adipiscing.",
                    Tags = "setup, settings, configurations",
                    CreatedOn = DateTime.Now
                }
            );
        }
    }
}
