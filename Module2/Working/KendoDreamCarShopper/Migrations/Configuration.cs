using System;
using System.Data.Entity.Migrations;
using System.Linq;
using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<EntityStore> {

        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityStore context) {
            const string imageUrlBase = "/Content/images{0}";

            //Makes
            const string ferrariName = "Ferrari";
            const string lamborghiniName = "Lamborghini";
            const string bentleyName = "Bentley";
            const string bugattiName = "Bugatti";
            const string koenigseggName = "Koenigsegg";
            const string porscheName = "Porsche";
            string makeImageUrlBase = string.Format(imageUrlBase, "/Makes/{0}.png");
            Make ferrari = new Make {Name = ferrariName, Location = "Maranello, Italy", ImageUrl = string.Format(makeImageUrlBase, ferrariName)};
            Make lamborghini = new Make {Name = lamborghiniName, Location = "Sant'Agata Bolognese, Italy", ImageUrl = string.Format(makeImageUrlBase, lamborghiniName)};
            Make bentley = new Make {Name = bentleyName, Location = "Crewe, Cheshire, England", ImageUrl = string.Format(makeImageUrlBase, bentleyName)};
            Make bugatti = new Make {Name = bugattiName, Location = "Molsheim, France", ImageUrl = string.Format(makeImageUrlBase, bugattiName)};
            Make koenigsegg = new Make {Name = koenigseggName, Location = "Ängelholm, Sweden", ImageUrl = string.Format(makeImageUrlBase, koenigseggName)};
            Make porsche = new Make {Name = porscheName, Location = "Weissach, Germany", ImageUrl = string.Format(makeImageUrlBase, porscheName)};
            context.Makes.AddOrUpdate(m => m.Name, ferrari, lamborghini, bentley, bugatti, koenigsegg, porsche);

            //Models
            int ferrariId = context.Makes.First(x => x.Name == ferrariName).Id;
            int lamboId = context.Makes.First(x => x.Name == lamborghiniName).Id;
            int bentleyId = context.Makes.First(x => x.Name == bentleyName).Id;
            int bugattiId = context.Makes.First(x => x.Name == bugattiName).Id;
            Model ferrari458Spider = new Model {MakeId = ferrariId, Year = 2013, Name = "458 Spider", Description = "The Ferrari 458 Spider offers a whole new set of emotions and adds a genuine sense of sportiness and power to weekend trips à deux. A clever mix of sounds supplied by the car’s 570 horse power incorporates just the right notes, turning it into music to your ears: music that acts as a brilliant soundtrack not only to the pleasure of driving a Prancing Horse car but in-car chat.", EngineType = "V8 - 90° - Direct Injection - Dry Sump", BreakHorsepower = 570, ZeroToSixty = 3.1m, TopSpeed = 199, BasePrice = 257000};
            Model lamboAventador = new Model {MakeId = lamboId, Year = 2013, Name = "Aventador LP 700-4", Description = "The Aventador LP 700-4 represents a whole new level of performance, sets new benchmarks in the super sports car segment, and provides a glimpse into the future. It’s a car that’s already achieved legendary status.", EngineType = "V12, 60°, MPI", BreakHorsepower = 700, ZeroToSixty = 2.7m, TopSpeed = 217, BasePrice = 397500};
            Model bentleyContinental = new Model {MakeId = bentleyId, Year = 2013, Name = "Contintental GT", Description = "From the company’s earliest days, our cars set new standards in automotive design and engineering. They were icons of motoring. These cars took the Grand Touring rulebook and rewrote it. The beautiful R-Type Continental in the 1950s and the Continental GT at the start of the 21st century. A revolution in Grand Touring At the start of a new decade we unveiled our masterpiece, the Continental GT. A stunning coupé that blends classic Bentley DNA with contemporary design and modern technology. The perfect fusion of supercar performance and handcrafted luxury ensures the remarkable, the Continental GT creates a revolution of its own. Welcome to a new chapter in Bentley's automotive history.", EngineType = "5998cc V12", BreakHorsepower = 567, ZeroToSixty = 4.3m, TopSpeed = 198, BasePrice = 215000};
            Model bugattiVeryron = new Model {MakeId = bugattiId, Year = 2013, Name = "Veyron 16.4", Description = "Boasting a maximum speed of more than 400 km per hour, the Veyron is unmatched in the super sports category. It offers a total of 736 kW (1,001 HP), and its ample power reserves even at high speeds are the fabric of dreams for luxury-class limousines: for a constant speed of 250 km/h, the Veyron only needs 270-280 HP. This means that the seven-gear clutch transmission works with a torque of up to 1,250 Newton meters. The Electronic Stability Program ensures the necessary flexibility and maneuverability at any speed. The Veyron reaches velocities that would literally lift the car off the ground – if it weren’t for its ingenious aerodynamics, which keeps it firmly on the road even at full speed. Adjusting the back spoiler, reducing ground clearance, opening and closing the lids – it all adds to the perfect balance between propulsion and downforce. Such a super sports car may not seem to be brought to a halt easily, but the Veyron’s ceramic brakes slow it down faster than it can accelerate. While it takes this exceptional car only 2.5 seconds to go from 0 to 100 km/h, it needs even less time – a mere 2.3 seconds – to come to a standstill from 100 (reference point). To reduce the risk of injuries in accidents, Bugatti had a Formula 1 safety concept adapted for the Veyron. All these technical details combine to make the Veyron a truly exceptional super sports car.", EngineType = "8.0 Liter W16", BreakHorsepower = 1001, ZeroToSixty = 2.5m, TopSpeed = 253, BasePrice = 1914000};
            context.Models.AddOrUpdate(m => m.Name, ferrari458Spider, lamboAventador, bentleyContinental, bugattiVeryron);

            //Model Images
            string spiderImageBase = string.Format(imageUrlBase, "/Models/Ferrari458Spider/{0}.png");
            string aventadorImageBase = string.Format(imageUrlBase, "/Models/LamborghiniAventadorLP700-4/{0}.png");
            int spiderId = context.Models.First(x => x.Name == "458 Spider").Id;
            int aventadorId = context.Models.First(x => x.Name == "Aventador LP 700-4").Id;
            context.ModelImages.AddOrUpdate(x => new {x.ModelId, x.Order}, new Models.ModelImage {ModelId = spiderId, ShortDescription = "Front", LongDescription = "Front", Order = 1, HighResolutionUrl = string.Format(spiderImageBase, "Front_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Front_LowRez")}, new Models.ModelImage {ModelId = spiderId, ShortDescription = "Rear", LongDescription = "Rear", Order = 2, HighResolutionUrl = string.Format(spiderImageBase, "Rear_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Rear_LowRez")}, new Models.ModelImage {ModelId = spiderId, ShortDescription = "Side", LongDescription = "Side", Order = 3, HighResolutionUrl = string.Format(spiderImageBase, "Side_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Side_LowRez")}, new Models.ModelImage {ModelId = spiderId, ShortDescription = "Top", LongDescription = "Top", Order = 4, HighResolutionUrl = string.Format(spiderImageBase, "Top_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Top_LowRez")}, new Models.ModelImage {ModelId = aventadorId, ShortDescription = "Front", LongDescription = "Front", Order = 1, HighResolutionUrl = string.Format(aventadorImageBase, "Front_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Front_LowRez")}, new Models.ModelImage {ModelId = aventadorId, ShortDescription = "Rear", LongDescription = "Rear", Order = 2, HighResolutionUrl = string.Format(aventadorImageBase, "Rear_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Rear_LowRez")}, new Models.ModelImage {ModelId = aventadorId, ShortDescription = "Side", LongDescription = "Side", Order = 3, HighResolutionUrl = string.Format(aventadorImageBase, "Side_HighRez"), LowResolutionUrl = string.Format(spiderImageBase, "Side_LowRez")});

            //Order
            const string username = "TestAccount";
            context.Orders.AddOrUpdate(x => new {x.Username, x.MakeId, x.ModelId}, new Order {Username = username, MakeId = ferrariId, ModelId = spiderId, Date = DateTime.Now.AddDays(-7), TotalCharge = 280465});
        }
    }
}