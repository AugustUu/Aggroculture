using Godot;
using Godot.Collections;
using System;
using System.Threading;

public partial class movement : CharacterBody3D
{

	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	public float playerRotation = 0;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	[Export]
	public Camera3D camera { get; set; }

	[Export]
	public MeshInstance3D model;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	float mouseStart = 0;

	/*

	LEAVE THIS

	Vector2 mouse_position = GetViewport().GetMousePosition();
	Vector3 origin = camera.ProjectRayOrigin(mouse_position);
	Vector3 end = origin + camera.ProjectRayNormal(mouse_position) * 100;

	PhysicsRayQueryParameters3D a = PhysicsRayQueryParameters3D.Create(origin, end);

	Dictionary res = GetWorld3D().DirectSpaceState.IntersectRay(a);
	GD.Print(res);
	*/

	
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;


		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y -= gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;

		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		if(Input.IsActionPressed("ADS")){
			Vector2 player_pos = camera.UnprojectPosition(Position);
			Vector2 mouse_pos = GetViewport().GetMousePosition();

			playerRotation = this.Rotation.Y + Mathf.Atan2(player_pos.Y - mouse_pos.Y, mouse_pos.X - player_pos.X) + Mathf.Pi / 2; // this shit is fucked dont change

		}else{
			if (direction != Vector3.Zero){
				playerRotation = new Vector2(-velocity.X,velocity.Z).Angle() - Mathf.Pi/2;
			}
		}

		Vector2 mouse_position = GetViewport().GetMousePosition() - GetViewport().GetVisibleRect().Size/2;


		if(Input.IsActionJustPressed("drag")){
			mouseStart = mouse_position.X;
		}else if(Input.IsActionPressed("drag") && mouseStart != mouse_position.X){
			Vector3 rot = this.Rotation;
			float mouse = (mouse_position.X - mouseStart)/100;
			GD.Print(mouse);
			rot.Y -= mouse;
			this.Rotation = rot;
			mouseStart = mouse_position.X;
		}

		Vector3 rotation = model.GlobalRotation;
		rotation.Y = (float)Mathf.LerpAngle(rotation.Y,playerRotation,0.2);
		model.GlobalRotation = rotation;


		Velocity = velocity;
		MoveAndSlide();
	}




}
