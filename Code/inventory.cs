using Godot;
using System;

public partial class inventory : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Visible = false;
	}


	public override void _UnhandledInput(InputEvent @event){
		if(@event.IsActionPressed("inventory")){
			this.Visible = !this.Visible;
		}
	}
}
