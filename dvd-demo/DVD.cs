using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class DVD
    {
        Vector2 position;
        Vector2 velocity;

        Vector2 collisionRect = new Vector2(120, 70);
        Color color;
        public void Setup()
        {
            color = Random.Color();
            position = new Vector2(300, 300);

            // speeds are always in pixels per second
            velocity = Random.Vector2() * 150.0f;
        }

        public void Update()
        {
            ProcessPhysics();
            bool isColliding = ProcessCollisions();

            // if it collides with a wall, re-randomize color
            if (isColliding)
            {
                color = Random.Color();
            }
            DrawDVD();
        }

        void ProcessPhysics()
        {
            position += velocity * Time.DeltaTime;
        }

        bool ProcessCollisions()
        {
            float halfX = collisionRect.X / 2.0f;
            float halfY = collisionRect.Y / 2.0f;
            float leftEdge = position.X - halfX;
            float rightEdge = position.X + halfX;
            float topEdge = position.Y - halfY;
            float bottomEdge = position.Y + halfY;

            bool isColliding = false;
            if (leftEdge < 0)
            {
                isColliding = true;
                velocity.X *= -1;
                position.X = 0 + halfX;
            }
            if (rightEdge > Window.Width)
            {
                isColliding = true;
                velocity.X *= -1;
                position.X = Window.Width - halfX;
            }
            if (topEdge < 0)
            {
                isColliding = true;
                velocity.Y *= -1;
                position.Y = 0 + halfY;
            }
            if (bottomEdge < Window.Height)
            {
                isColliding = true;
                velocity.Y *= -1;
                position.Y = Window.Width - halfX;
            }
        }

        void DrawDVD()
        {
            // testing - visualize the hitbox
            /*
            Draw.LineSize = 1;
            Draw.LineColor = new Color("0FFF50");
            Draw.FillColor = Color.Black;
            Draw.Rectangle(position - collisionRect / 2.0f, collisionRect);
            */

            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Ellipse(position + new Vector2(0, 20), new Vector2(100, 20));

            Draw.FillColor = Color.Black;
            Draw.Ellipse(position + new Vector2(0, 20), new Vector2(30, 5));

            Vector2 dvdTextOffset = new Vector2(-25, -40 + 20);
            Text.Color = Color.White;
            Text.Draw("DVD", position + dvdTextOffset);
        }
    }
}
