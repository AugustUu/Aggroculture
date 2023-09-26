using Godot;
using Godot.Collections;
using System;
using System.Threading;

public partial class movement : CharacterBody3D
{

	public const float Speed = 3f;
	public const float JumpVelocity = 4.5f;

	public float playerRotation = 0;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	[Export]
	public Camera3D camera;

	[Export]
	public MeshInstance3D model;

	[Export]
	public int sensitivity = 300;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	float mouse_start = 0;

	/*

	LEAVE THIS

	Vector2 mouse_position = GetViewport().GetMousePosition();
	Vector3 origin = camera.ProjectRayOrigin(mouse_position);
	Vector3 end = origin + camera.ProjectRayNormal(mouse_position) * 100;

	PhysicsRayQueryParameters3D a = PhysicsRayQueryParameters3D.Create(origin, end);

	Dictionary res = GetWorld3D().DirectSpaceState.IntersectRay(a);
	GD.Print(res);
	*/

	public void Rotate(Vector3 velocity){
		SpotLight3D light = GetNode<SpotLight3D>("flashlight");
		Vector2 mouse_pos = GetViewport().GetMousePosition();

		if(Input.IsActionPressed("ADS")){
			Vector2 player_pos = camera.UnprojectPosition(Position);
			velocity.X = velocity.X*0.666f;
			velocity.Z = velocity.Z*0.666f;
			playerRotation = this.Rotation.Y + Mathf.Atan2(player_pos.Y - mouse_pos.Y, mouse_pos.X - player_pos.X) + Mathf.Pi / 2; // this shit is fucked dont change

		}else{
			if (velocity != Vector3.Zero){
				playerRotation = new Vector2(-velocity.X,velocity.Z).Angle() - Mathf.Pi/2;
			}
		}
		
		Vector2 mouse_position = mouse_pos - GetViewport().GetVisibleRect().Size/2;

		if(Input.IsActionJustPressed("drag")){
			mouse_start = mouse_position.X;
		}else if(Input.IsActionPressed("drag") && mouse_start != mouse_position.X){
			Vector3 rot = this.Rotation;
			rot.Y -= (mouse_position.X - mouse_start) / sensitivity;
			this.Rotation = rot;
			mouse_start = mouse_position.X;
		}
		
		Vector3 rotation = model.GlobalRotation;
		rotation.Y = (float)Mathf.LerpAngle(rotation.Y, playerRotation, 0.2);
		model.GlobalRotation = rotation;
		light.GlobalRotation = rotation - new Vector3(0, MathF.PI, 0);
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;


		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y -= gravity * (float)delta;
		}

		// Handle Jump.
		/*if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		*/
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if(direction != Vector3.Zero && Input.IsActionPressed("sprint") && Input.IsActionPressed("ADS")){
			velocity.X = direction.X * Speed*2*0.666f;
			velocity.Z = direction.Z * Speed*2*0.666f;

		}else if(direction != Vector3.Zero && Input.IsActionPressed("sprint"))
		{
			velocity.X = direction.X * Speed*2f;
			velocity.Z = direction.Z * Speed*2f;
		}else if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;

		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Rotate(velocity);

		Velocity = velocity;
		MoveAndSlide();
	}




}
