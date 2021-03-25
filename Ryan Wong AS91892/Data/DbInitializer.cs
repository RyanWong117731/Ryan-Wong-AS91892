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
                new Store{Location="Cloud City"},
                new Store{Location="Hyrule"},
                new Store{Location="Horizon Lunar Colony"},
                new Store{Location="Snowdin"},
                new Store{Location="New Donk City"}
           };

            context.Stores.AddRange(Stores);
            context.SaveChanges();

            var Items = new Item[]
            {
                new Item {Name="Buster Sword",Description="Big Sword",Price=12,ItemType="Sword",StoreID=2},
                new Item {Name="Hawkmoon",Description="Holding Aces",Price=25,ItemType="Hand Cannon",StoreID=3},
                new Item {Name="Chaos Shield",Description="Bulls Rush Has Extended Range",Price=25,ItemType="Shield",StoreID=3},
                new Item {Name="Spartan Lazer",Description="Long Range Charge Rifle",Price=25,ItemType="Railgun",StoreID=3},
                new Item {Name="Gjallarhorn",Description="Wolfpack Round Release After Detonation",Price=35,ItemType="Rocket Launcher",StoreID=5},
                new Item {Name="Max Revive",Description="Revives A Fallen Ally To Full Health",Price=50,ItemType="Potion",StoreID=1}

            };

            context.Items.AddRange(Items);
            context.SaveChanges();

            var Staffs = new Staff[]
            {
                new Staff{FirstName="Gus", LastName="Carsons",HireDate=DateTime.Parse("2019-09-01"),Wages=8, StoreID=1 },
                new Staff{FirstName="Winston", LastName=" ",HireDate=DateTime.Parse("2016-05-24"),Wages=5,StoreID=3},
                new Staff{FirstName="Banshee", LastName="44",HireDate=DateTime.Parse("2010-02-12"),Wages=25,StoreID=5},
                new Staff{FirstName="Temmi", LastName="e",HireDate=DateTime.Parse("2015-10-24"),Wages=15,StoreID=4}
            };

            context.Staffs.AddRange(Staffs);
            context.SaveChanges();

           
        }
    }
}
