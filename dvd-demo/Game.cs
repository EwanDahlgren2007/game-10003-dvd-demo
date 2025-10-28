// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        DVD dvdA;
        public void Setup()
        {
            Window.SetTitle("DVD Demo");
            Window.SetSize(800, 600);

            dvdA = new DVD();
            dvdA.Setup();
        }
        public void Update()
        {
            dvdA.Update();
        }
    }

}
