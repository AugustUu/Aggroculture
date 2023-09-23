using Godot;
using System;
using System.ComponentModel;

public partial class dayTime : Timer
{
	public static int minutes_In_Day = 600;
	public static int minutes_In_Hour = 60;
	public static double tRMD = (2 * 3.1419) / minutes_In_Day;

	double time = 0.0;
	int pastMin = -1;
	int startHour = 12;
	double Ingame_Speed = 2.4;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		time += delta * tRMD * Ingame_Speed;
		recalculate_time();
		
	}
	private void _on_timeout()
	{
	}


	public void recalculate_time(){
		int total_min = (int)(time/tRMD);
		int day = (int)(total_min/minutes_In_Day);
		int current_day_minutes = total_min % minutes_In_Day;
		int hours = (int)(current_day_minutes/minutes_In_Hour);
		int minutes = (int)(current_day_minutes % minutes_In_Hour);
		Label onScreenTime = GetNode<Label>("Time");
		Label onScreenDays = GetNode<Label>("Days");
		if(hours == 0 && minutes < 10){
			onScreenTime.Text = "12 : 0"+minutes.ToString();
		}
		else if(hours == 0){
			onScreenTime.Text = "12 : "+minutes.ToString();
		}
		else if(minutes < 10){
			onScreenTime.Text = hours.ToString()+" : 0"+minutes.ToString();
		}
		else{
			onScreenTime.Text = hours.ToString()+" : "+minutes.ToString();
		}

		onScreenDays.Text = "Day "+day;
		if(pastMin != minutes){
			pastMin = minutes;
		}
	}
}
