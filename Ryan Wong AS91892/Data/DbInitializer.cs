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


            if (context.Items.Any())
            {
                return;   
            }

            var Stores = new Store[]
           {
                new Store{Location="Hell"},
                new Store{Location="Somewhere"}
           };

            context.Stores.AddRange(Stores);
            context.SaveChanges();


            var Items = new Item[]
            {
                new Item {Name="Gun",Description="Bang!",Price=12,ItemType="Weapon",StoreID=2},
                new Item {Name="Knife",Description="ow",Price=11,ItemType="Weapon",StoreID=2},
                new Item {Name="Strong potion",Description="you cannot handle my potions traveler",Price=5,ItemType="Potion",StoreID=1}

            };

            context.Items.AddRange(Items);
            context.SaveChanges();

            var Staffs = new Staff[]
            {
                new Staff{FirstName="Gus", LastName="Carsons",HireDate=DateTime.Parse("2019-09-01"),Wages=5, StoreID=1 },
                new Staff{FirstName="Steve", LastName="Creggory",HireDate=DateTime.Parse("2018-02-14"),Wages=10,StoreID=2},
                new Staff{FirstName="Guy", LastName="Jones",HireDate=DateTime.Parse("2015-10-24"),Wages=2,StoreID=1}
            };

            context.Staffs.AddRange(Staffs);
            context.SaveChanges();

           
        }
    }
}
