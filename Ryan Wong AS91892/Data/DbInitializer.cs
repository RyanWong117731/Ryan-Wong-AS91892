using System;
using System.Collections.Generic;
using System.Linq;
using Ryan_Wong_AS91892.Data;
using Ryan_Wong_AS91892.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ryan_Wong_AS91892.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ItemShopContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            var Items = new Item[]
            {
                new Item {Name="Gun",Description="Bang!",Price=12,ItemType="Weapon",},
                new Item {Name="Knife",Description="ow",Price=11,ItemType="Weapon"},
                new Item {Name="Strong potion",Description="you cannot handle my potions traveler",Price=5,ItemType="Potion"}

            };

            context.Items.AddRange(Items);
            context.SaveChanges();

            var Staffs = new Staff[]
            {
                new Staff{FirstName="Gus", LastName="Carsons",HireDate=DateTime.Parse("2019-09-01"),Wages=5},
                new Staff{FirstName="Steve", LastName="Creggory",HireDate=DateTime.Parse("2018-02-14"),Wages=10},
                new Staff{FirstName="Guy", LastName="Jones",HireDate=DateTime.Parse("2015-10-24"),Wages=2}
            };

            context.Staffs.AddRange(Staffs);
            context.SaveChanges();

            var Stores = new Store[]
            {
                new Store{Location="Hell"},
                new Store{Location="Somewhere"}

            };

            context.Stores.AddRange(Stores);
            context.SaveChanges();

            var ItemAssignments = new ItemAssignment[]
            {
                new ItemAssignment{ItemID=1,StoreID=1}

            };

            context.ItemAssignments.AddRange(ItemAssignments);
            context.SaveChanges();

            var StaffAssignments = new StaffAssignment[]
            {
                new StaffAssignment{StaffID=1,StoreID=1}

            };

            context.StaffAssignments.AddRange(StaffAssignments);
            context.SaveChanges();
        }
    }
}
