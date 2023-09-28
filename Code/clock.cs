using Godot;
using System;

public partial class clock : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(dayTime.minutes >= 10){
			this.Text = dayTime.hours+" : "+dayTime.minutes;
		}else{
			this.Text = dayTime.hours+" : 0"+dayTime.minutes;
		}
	}
}
