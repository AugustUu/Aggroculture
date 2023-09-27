using System;
using System.Runtime.CompilerServices;
using Godot;
public partial class dayTime : Timer
{
	[Export]
	public static int minutes = 0;
	
	[Export]
	public static int hours = 5;

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


	public override void _Process(double delta){
		Vector3 rotation = sun.Rotation;
		rotation.X = (float)Mathf.LerpAngle(rotation.X,(float)((hours* 60 + minutes) / 1440.0 * 2*Math.PI),delta);
		
		sun.Rotation = rotation;
	}

	//Changes from raw int time into hours, mins, days.
	public void recalculate_time(){



		if(minutes >= 60){
			minutes -= 60;
			hours += 1;
		}

		if(hours >= 24){
			hours = 0;
			days += 1;
		}
	}
}
