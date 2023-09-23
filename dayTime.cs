using System;
using System.Runtime.CompilerServices;
using Godot;
//IMPORANT: TO CHANGE THE TIME IN THE DAY CHANGE THE TIME_IN_DAY VARIABLE
public partial class dayTime : Timer
{
	int TIME_IN_DAY = 288;
	int minutes;
	int hours = 0;

	int days = 0;
	Vector3 rotX = new Vector3(0,0,0);
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		recalculate_time();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	private void  _on_timeout()
	{

		MeshInstance3D sun = GetNode<MeshInstance3D>("Dial");
		minutes += 5;
		recalculate_time();
		//To be made smooth sun transitions I dont really know how tweeners work.
		//Tween sunTween = GetTree().CreateTween();
		//sunTween.TweenProperty(sun,"rotation",,0.6);
		//sunTween.TweenProperty(sun,"Rotate",Vector3.One, 2.0f);
		sun.RotateX((float)(2*Math.PI/TIME_IN_DAY));
		GD.Print(sun.Rotation);
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
		//setting labels to show coresponding data.
		Label onScreenTime = GetNode<Label>("Time");
		Label onScreenDays = GetNode<Label>("Days");
		onScreenTime.Text = hours.ToString()+" : "+minutes.ToString();
		onScreenDays.Text = "Day "+days;
	}
}
