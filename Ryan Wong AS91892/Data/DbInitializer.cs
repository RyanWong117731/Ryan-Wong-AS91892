using System;
using System.Collections.Generic;
using System.Linq;
using Ryan_Wong_AS91892.Data;
using Ryan_Wong_AS91892.Models;
using System.Threading.Tasks;

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
                new Item {Name="Gun",Description="Bang!",Price=12,ItemType="Weapon"}
               
            };

            context.Items.AddRange(Items);
            context.SaveChanges();

            var Staff = new Staff[]
            {
                new Staff{FirstName="Gus", LastName="Carsons",HireDate=DateTime.Parse("2019-09-01"),Wages=5}
            };

            context.Staff.AddRange(Staff);
            context.SaveChanges();

            var Stores = new Store[]
            {
                new Store{Name="Store 1",Location="Hell",ItemID=1,StaffID=1,}

            };

            context.Stores.AddRange(Stores);
            context.SaveChanges();
        }
    }
}
