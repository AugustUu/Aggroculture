using Godot;

public partial class flashlight : SpotLight3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

public override void _UnhandledInput(InputEvent @event){
	OmniLight3D light = GetChild<OmniLight3D>(0);
		if(@event.IsActionPressed("flashlight") && this.LightEnergy == 9.0f){
			this.LightEnergy = 0.0f;
			light.LightEnergy = 0.0f;
		}
		else if(@event.IsActionPressed("flashlight") && this.LightEnergy == 0.0f){
			this.LightEnergy = 9.0f;
			light.LightEnergy = 1.0f;
		}
	}
}
