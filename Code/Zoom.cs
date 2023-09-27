using Godot;
using System;

public partial class Zoom : Camera3D
{
	//called when key pressed
	public override void _UnhandledInput(InputEvent @event){
		if(@event.IsActionPressed("zoom-in")){
			this.Position = new Vector3(this.Position.X, this.Position.Y*0.8f, this.Position.Z*0.8f);
			GD.Print(this.Position);
		}
		if(@event.IsActionPressed("zoom-out")){
			this.Position = new Vector3(this.Position.X, this.Position.Y*1.25f, this.Position.Z*1.25f);
			GD.Print(this.Position);
		}
		Vector3 clampPos = this.Position;
		clampPos.Y = Mathf.Clamp(clampPos.Y, 2.1f, 12.5f);
		clampPos.Z = Mathf.Clamp(clampPos.Z, 0.786f, 4.688f);
		this.Position = clampPos;
	}
}
