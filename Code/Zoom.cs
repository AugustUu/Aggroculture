using Godot;
using System;

public partial class Zoom : Camera3D
{
	//called when key pressed
	public override void _UnhandledInput(InputEvent @event){
		if(@event.IsActionPressed("zoom-in")){
			this.Fov -= 10f;
		}
		if(@event.IsActionPressed("zoom-out")){
			this.Fov += 10f;
		}
		this.Fov = Mathf.Clamp(this.Fov,20f,100f);
	}
}
