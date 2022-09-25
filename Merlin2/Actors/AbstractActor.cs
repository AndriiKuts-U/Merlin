using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;

namespace Merlin2.Actors
{
    public abstract class AbstractActor : IActor
    {
        private Animation animation;
        private int x;
        private string name;
        private int y;
        private int leftX;
        private int rightX;
        private int leftY;
        private int rightY;
        private int playerLeftX;
        private int playerRightX;
        private int playerLeftY;
        private int playerRightY;
        private IWorld world;
        
    
        private bool isPhysicsEnabled;
        private bool isRemooved;
        public Animation GetAnimation()
        {
            return animation;
        }

        public int GetHeight()
        {
            return this.animation.GetHeight();
        }

        public string GetName()
        {
            return name;
        }

        public int GetWidth()
        {
            return this.animation.GetWidth();
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool IntersectsWithActor(IActor other)
        {


            leftX = other.GetX() ;
            rightX = other.GetX() + other.GetWidth() ;
            leftY = other.GetY() ;
            rightY = other.GetY() + other.GetHeight() ;

            playerLeftX = this.GetX() ;
            playerRightX = this.GetX() + this.GetWidth() ;
            playerLeftY = this.GetY();
            playerRightY = this.GetY() + this.GetHeight() ;

            if (rightX >= playerLeftX && rightX <= playerRightX && rightY >= playerLeftY && rightY <= playerRightY)
            {
                return true;
            }
            if (leftX <= playerRightX && leftX >= playerLeftX && leftY <= playerRightY && leftY >= playerLeftY)
            {
                return true;
            }

            

         
            return false;

   
        }

        public bool IsAffectedByPhysics()
        {
            if (isPhysicsEnabled) 
            {
                return true;
            }
            return false;
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public bool RemovedFromWorld()
        {
            return isRemooved;
        }
        
        public void RemoveFromWorld()
        {
            isRemooved = true;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            this.isPhysicsEnabled = isPhysicsEnabled;
        }

        public void SetPosition(int posX, int posY)
        {
            x = posX;
            y = posY;
        }

        public abstract void Update();
        
    }
}