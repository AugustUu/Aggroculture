using Godot;
using System;
using System.ComponentModel;

public partial class dayTime : Timer
{
	int minutes;
	int hours = 0;

	int days = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		recalculate_time();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	private void  _on_timeout()
	{
		minutes += 5;
		recalculate_time();
	}


	public void recalculate_time(){
		if(minutes >= 60){
			minutes -= 60;
			hours += 1;
		}

		if(hours >= 24){
			hours = 0;
			days += 1;
		}



		Label onScreenTime = GetNode<Label>("Time");
		Label onScreenDays = GetNode<Label>("Days");
		onScreenTime.Text = hours.ToString()+" : "+minutes.ToString();

		onScreenDays.Text = "Day "+days;
	}
}
