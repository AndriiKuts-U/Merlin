using Merlin2d.Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Merlin2.Items
{
    public class Backpack : IInventory
    {
        private IItem[] items;
        private int capacity;
        private int position = 0;

        public Backpack( int capacity)
        {
            items = new IItem[capacity];
            this.capacity = capacity;
        }

        public void AddItem(IItem item)
        {
            items[position++] = item;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            foreach (IItem item in items)
            {
                if(item == null)
                {
                    break;
                }
                yield return item;
            }
        }

        public IItem GetItem()
        {
            return items[position];
        }

        public void RemoveItem(IItem item)
        {
            item.RemoveFromWorld();
            //for (int i = 0; i < capacity; i++) { 

            //    if(items[i] == item)
            //    {
            //        RemoveItem(i);
            //    }
            //}
        }

        public void RemoveItem(int index)
        {
            items[index].RemoveFromWorld();
        }
        
        public void ShiftLeft()
        {
            IItem item ;
            item = items[0];
            
            for (int i = 1; i < capacity ; i++)
            {
                
                items[i - 1] = items[i]; 
                
            }
            items[capacity - 1] = item;
        }

        public void ShiftRight()
        {
            IItem item;
            item = items[capacity-1];

            for (int i = capacity - 1; i >= 1; i--)
            {
                items[i ] = items[i-1];

            }
            items[0] = item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
