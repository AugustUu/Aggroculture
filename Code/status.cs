using Godot;
using System;

public partial class status : Label
{
	public static int hunger = 1000;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Text = (hunger/10).ToString();
	}
}
