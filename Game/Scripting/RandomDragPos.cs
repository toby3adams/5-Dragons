using System;
using System.Collections;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using Dragons.Game;
using System.Linq;

namespace Dragons.Game.Scripting{

    public class RandomDragPos 
    {
        int position_counter = 4;
        List<Point> points = new List<Point>();
        
        Random rnd = new Random();
            
        public RandomDragPos(){}

        public void GeneratePositions()
        {
            // generates random x and y values within desired range.
            int pos_1_x = rnd.Next(0,1000);
            int pos_1_y = rnd.Next(0,1000);
            //
            int pos_2_x = rnd.Next(1001,2000);
            int pos_2_y = rnd.Next(0,1000);
            //
            int pos_3_x = rnd.Next(0,1000);
            int pos_3_y = rnd.Next(1001,2000);
            //
            int pos_4_x = rnd.Next(1001,2000);
            int pos_4_y = rnd.Next(1001,2000);
            //
            int pos_5_x = rnd.Next(2001, 3000);
            int pos_5_y = rnd.Next(0,2000);
            // logic and while statement ensures the pos_1 x and y are divisible by 5 for collision
            if(pos_1_x % 5 != 0)
            {
                while(pos_1_x % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_1_x += 1;
                }
            }
            if(pos_1_y % 5 != 0)
            {
                while(pos_1_y % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_1_y += 1;
                }
            }
            // logic and while statement ensures the pos_2 x and y are divisible by 5 for collision
            if(pos_2_x % 5 != 0)
            {
                while(pos_2_x % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_2_x += 1;
                }
            }
            if(pos_2_y % 5 != 0)
            {
                while(pos_2_y % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_2_y += 1;
                }
            }
            // logic and while statement ensures the pos_3 x and y are divisible by 5 for collision
            if(pos_3_x % 5 != 0)
            {
                while(pos_3_x % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_3_x += 1;
                }
            }
            if(pos_3_y % 5 != 0)
            {
                while(pos_3_y % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_3_y += 1;
                }
            }
            // logic and while statement ensures the pos_4 x and y are divisible by 5 for collision
            if(pos_4_x % 5 != 0)
            {
                while(pos_4_x % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_4_x += 1;
                }
            }
            if(pos_4_y % 5 != 0)
            {
                while(pos_4_y % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_4_y += 1;
                }
            }
            // logic and while statement ensures the pos_5 x and y are divisible by 5 for collision
            if(pos_5_x % 5 != 0)
            {
                while(pos_5_x % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_5_x += 1;
                }
            }
            if(pos_5_y % 5 != 0)
            {
                while(pos_5_y % 5 != 0) // loops and increments coordinate until the value is divisible by 5.
                {
                    pos_5_y += 1;
                }
            }  
            Point pos_1 = new Point(pos_1_x, pos_1_y);                     
            points.Add(pos_1);

            Point pos_2 = new Point(pos_2_x, pos_2_y);                      
            points.Add(pos_2);
            
            Point pos_3 = new Point(pos_3_x, pos_3_y);        
            points.Add(pos_3);
             
            Point pos_4 = new Point(pos_4_x, pos_4_y);       
            points.Add(pos_4);
            
            Point pos_5 = new Point(pos_5_x, pos_5_y);
            points.Add(pos_5);

            List<Point> points_shuf = points.OrderBy(x => rnd.Next()).ToList();    
            
        }
        public Point GetPosition()
        {   
            Point point = points[position_counter];
            Console.WriteLine($"Pos index: {position_counter}");
            points.RemoveAt(position_counter);
            position_counter = position_counter - 1;
           
            return point;
        }
    }
}