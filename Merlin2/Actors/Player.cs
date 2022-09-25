using Merlin2.Commands;
using Merlin2.Spells;
using Merlin2.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace Merlin2.Actors
{
    public class Player : AbstractCharacter, IMovable, IWizard
    {
        private Command moveLeft;
        private Command moveRight;
        private Command jump;
        private Animation animation;
        private bool isLeft = false;
        private bool isKeyPressed = false;
        private bool isJumped = false;
        private int acceleration = 15;
        private int height = 0;
        private int mana;
        
      
        public Player() 
        {
           SetPhysics(true);

            animation = new Animation("Resources/sprites/new_player.png", 28,47 );
            NormalSpeedStrategy strategy = new NormalSpeedStrategy();
            this.SetSpeedStrategy( strategy);
            SetAnimation(animation);

            ChangeHealth(100);

            moveLeft = new Move(this, this.GetSpeed(3.7) , -1 , 0);
            moveRight = new Move(this, this.GetSpeed(3.7), 1, 0);
           
            jump = new Jump(this, 180, 10,acceleration );
            animation.Start();
            base.Update();
            //Console.WriteLine($"\n\nCreated{this.GetX() },{this.GetY()}\n\n");
        }

        public void Cast(ISpell spell)
        {
            ISpellDirector director = new SpellDirector(this,SpellDataProvider.GetInstance());
        }
       

        public void ChangeMana(int delta)
        {
            mana = mana * delta;
        }

        public int GetMana()
        {
            return mana;       
        }

        public override void Update()
        {
            base.Update();
            
          //  Console.WriteLine($"\n\n{this.GetX() },{this.GetY()}\n\n");
            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {

                if(isLeft == false) 
                {
                    animation.FlipAnimation();
                }
                isKeyPressed = true;
                isLeft = true;
                moveLeft.Execute();
              
    
            }

            if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                
                if (isLeft == true)
                {
                    animation.FlipAnimation();
                }
                isLeft = false;
                isKeyPressed = true;
                moveRight.Execute();

            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.SPACE))
            {
                 if (GetWorld().IsWall(this.GetX() / 16   , (this.GetY() ) / 16 + 3  ))
                {
                    height = this.GetY();
                    isJumped = true;  
                }
               
                   
            }
        
            if (isJumped == true )
            {
                if ( (height - 180) < this.GetY())
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
            
          
            if (isKeyPressed)
            {
                animation.Start();
            }
            else
            {
                animation.Stop();
            }
            isKeyPressed = false;
            
            

        }
    }
}
