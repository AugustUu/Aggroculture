using Godot;
using System;

public partial class worldGen : GridMap
{
    public override void _Ready()
    {

        FastNoiseLite noise = new();
        noise.NoiseType = FastNoiseLite.NoiseTypeEnum.Simplex;
        noise.FractalGain = 0;

        for (int x = -200; x < 200; x++)
        {
            for (int z = -200; z < 200; z++)
            {
                int y = (int)Mathf.Floor(noise.GetNoise2D(x, z) * 3);
                SetCellItem(new Vector3I(x, y, z), 0);
            }
        }
        //this.SetCellItem
    }

    public override void _Process(double delta)
	{
	}
}
