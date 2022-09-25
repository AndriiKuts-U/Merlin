using Merlin2.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Actors
{
    public class Enemy : AbstractCharacter
    {
        private Command moveLeft;
        private Command moveRight;
        private Command boostMoveLeft;
        private Command boostMoveRight;
        private Command jump;
        private Animation animation;
        private IActor player;

        private int counter = 0;
        Random random = new Random();
        private int randomDirection;
        private int isChanged;
        
        private int acceleration = 15;
        private int height = 0;  
        private bool isLeft = false;
        private bool isJumped = false;
        

        public Enemy(IActor player)
        {
            animation = new Animation("resources/sprites/new_enemy.png", 33, 47);
            SetPhysics(true); 
            SetAnimation(animation);
            moveLeft = new Move(this, 1, -1, 0);
            moveRight = new Move(this, 1, 1, 0);
            boostMoveLeft = new Move(this, 2, -1, 0);
            boostMoveRight = new Move(this, 2, 1, 0);
            animation.Start();

            jump = new Jump(this, 180, 10,acceleration);

            this.player = player;
           

        }
        public override void Update()
        {
            base.Update();
            if (this.IntersectsWithActor(player)) 
            {
                
                ((AbstractCharacter)player).ChangeHealth(-1);
                if (((AbstractCharacter)player).GetHealth() <= 0) 
                {
                    ((AbstractCharacter)player).Die();
                }
            }
            if (((this.GetX() - player.GetX()) < 200) || ((player.GetX() - this.GetX()) > 200) )
            {
                if (this.GetX() > player.GetX() && this.GetX() - player.GetX() != 1)
                {
                    if (isLeft == false)
                    {
                        animation.FlipAnimation();
                    }
                    randomDirection = 0;
                    isLeft = true;
                    boostMoveLeft.Execute();
                }
                else if (this.GetX() < player.GetX() && player.GetX() - this.GetX() != 1)
                {
                    if (isLeft == true)
                    {
                        animation.FlipAnimation();
                    }
                    randomDirection = 1;
                    isLeft = false;

                    boostMoveRight.Execute();
                }

                 if (this.GetY() > player.GetY() && this.GetX() != player.GetX()) 
                 {
                    if (GetWorld().IsWall(this.GetX() / 16 , (this.GetY()) / 16  + 3) && this.GetY() - player.GetY() < 30)
                    {
                        height = this.GetY();
                        isJumped = true;

                    }
                  
                 }

            }   
            else if((((this.GetX() - player.GetX()) > 200) || ((player.GetX() - this.GetX()) < 200)) && this.GetX() != player.GetX())
            {
                 if(counter >= 120)
                 {
                    isChanged = randomDirection;
                    randomDirection = random.Next(0, 2);
                   
                       if(isChanged != randomDirection)
                       { 
                             animation.FlipAnimation();
                             isLeft = !isLeft;
                       }
                            
                    counter = 0;
                 }

                    if (randomDirection % 2 == 0)
                    {
                    
                        moveLeft.Execute();
   
                    }
                    else
                    {
                    
                        moveRight.Execute();

                    }
            }
            if (this.GetX() == player.GetX())
            {
                animation.Stop();
            }
            else
            {
                animation.Start();
            }

            if (isJumped == true )
            {
                if ((height - 180) < this.GetY())
                {

                    jump.Execute();
                    if (this.GetWorld().IntersectWithWall(this))
                    {
                        this.SetPosition(this.GetX(), this.GetY() + 1);
                        isJumped = false;
                    }

                }
                else
                {
                    isJumped = false;
                }

            }


            counter++;
        }
    }
}
