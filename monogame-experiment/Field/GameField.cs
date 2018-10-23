﻿using System;

using Microsoft.Xna.Framework.Input;

using monogame_experiment.Desktop.Core;


namespace monogame_experiment.Desktop.Field
{
	// Game field scene
	public class GameField : Scene
    {

        // TEMP
		private float val = 0.0f;

		// Test bitmaps
		private Bitmap bmpFont;
		private Bitmap bmpTest;


		// Constructor
		public GameField() { /* ... */ }


		// Initialize scene
		override public void Init()
        {
			AssetPack assets = ((Global)globalScene).GetAssets();

			// Load assets
			bmpFont = assets.GetBitmap("font");
			bmpTest = assets.GetBitmap("test");
        }


        // Update scene
		override public void Update(float tm)
        {
			val += 0.05f * tm;
        }
      

        // Draw scene
		override public void Draw(Graphics g)
		{
			// Set matrices
			g.Identity();
			g.FitViewHeight(720.0f);
			g.Scale(1, 1);

			g.ToggleAutoBeginEnd(false);
			g.BeginDrawing();

			// Clear screen
			g.ClearScreen(170, 170, 170);

			// Draw test bitmap
			float s = (float)Math.Abs(Math.Sin(val));
			g.SetColor(s, 1.0f - s, 0.5f + s * 0.5f, 1.0f);
			g.FillRect(64, 64, 320, 240);
			g.DrawScaledBitmapRegion(bmpFont, 0, 0, 512, 256, 64, 0, 1024, 512, Graphics.Flip.Both);
           

			g.SetColor(1, 1, 1, s);
			g.DrawScaledBitmapRegion(bmpFont, 256, 256, 256, 256, 256, 256, 256, 256, Graphics.Flip.Vertical);

			// Hello world!
			g.SetColor();
			g.DrawText(bmpFont, "Hello world!\nAnd a thousand other cool things.", 32, 32, -16, 0, 0.75f, false);

			// End drawing
			g.EndDrawing();

			// Draw a spinning bitmap
			g.Translate(320, 320);
			g.Rotate(val);
  			g.BeginDrawing();

			g.SetColor(1, 1, 1, 1.0f-s);
			g.DrawBitmap(bmpTest, -128, -128);

			g.EndDrawing();
		}


        //Destroy scene
		override public void Destroy()
		{
			// ...
		}


        // Get name
		override public String getName()
		{
			return "game";
		}

    }
}