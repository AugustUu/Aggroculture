using Godot;
using System;

public partial class Zoom : Camera3D
{
	//called when key pressed
	public override void _UnhandledInput(InputEvent @event){
		if(@event.IsActionPressed("zoom-in")){
			this.Fov -= 5f;
		}
		if(@event.IsActionPressed("zoom-out")){
			this.Fov += 5f;
		}
		this.Fov = Mathf.Clamp(this.Fov,40f,100f);
	}
}
