using Godot;
using System;

public partial class label : Godot.Area3D
{	
	[Export]
	Label tempUI;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tempUI.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_body_entered(Node3D body)
	{
		if(body is CharacterBody3D){
			tempUI.Visible = true;
		}
	}
	public void _on_body_exited(Node3D body)
	{
		if(body is CharacterBody3D){
			tempUI.Visible = false;
		}
	}

}
