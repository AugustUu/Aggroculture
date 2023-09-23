using System;
using System.Runtime.CompilerServices;
using Godot;
public partial class dayTime : Timer
{
	[Export]
	public int minutes = 0;
	
	[Export]
	public int hours = 5;

	public static int days = 0;
	Vector3 rotX = new Vector3(0,0,0);
	

	[Export]
    public Node3D sun;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		recalculate_time();
	}
	

	private void  _on_timeout()
	{

		minutes += 5;
		recalculate_time();


	}

	//Changes from raw int time into hours, mins, days.
	public void recalculate_time(){


		Vector3 rotation = sun.Rotation; 
		rotation.X = (float)(((hours* 60 + minutes) / 1440.0) * 2*Math.PI);
		sun.Rotation = rotation;

		if(minutes >= 60){
			minutes -= 60;
			hours += 1;
		}

		if(hours >= 24){
			hours = 0;
			days += 1;
		}
		//setting labels to show coresponding data.
		Label onScreenTime = GetNode<Label>("Time");
		Label onScreenDays = GetNode<Label>("Days");
		onScreenTime.Text = hours.ToString()+" : "+minutes.ToString();
		onScreenDays.Text = "Day "+days;
	}
}
