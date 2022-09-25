using Merlin2.Actors;
using Merlin2.Commands;
using Merlin2.Factories;
using Merlin2.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using Merlin2d.Game.Items;
using System;

namespace Merlin2
{
   internal class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Merlin", 1920, 1080);
            IWorld world = container.GetWorld();

            CameraFollowStyle style = CameraFollowStyle.Centered;
            container.SetCameraFollowStyle(style);
            container.SetCameraZoom(2);

            ActorFactory factory = new ActorFactory();

            world.SetFactory(factory);
            Gravity gravity = new Gravity();
            world.SetPhysics(gravity);
            world.SetMap("resources/maps/d.tmx");

         

            IInventory backpack = new Backpack(5);
           
            backpack.AddItem(new ManaPotion());
            backpack.AddItem(new HealingPotion());
            backpack.AddItem(new PoisonPotion());

            Action<IWorld> setCamera = world =>
            {
                world.CenterOn(world.GetActors().Find(a => a.GetName() == "player"));

            };
            
           
            world.ShowInventory(backpack);


            world.AddInitAction(setCamera);
            container.Run();
            
        }
    }
}
