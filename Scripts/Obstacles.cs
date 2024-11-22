using Godot;
using System;

public partial class Obstacles : Area2D
{
	[Export] private float moveSpeed = 100f; 

	[Signal] public delegate void ScoredEventHandler();

	private Area2D scoreZone;

	public event Action Hit; 

	public override void _Ready()
	{
		scoreZone = GetNode<Area2D>("ScoreZone");
		scoreZone.AreaEntered += OnScoreZoneEntered;
		BodyEntered += _on_body_entered; 
	}

	public override void _Process(double delta)
	{
		Position += new Vector2(-moveSpeed * (float)delta, 0);

		
		if (Position.X < -GetViewportRect().Size.X)
		{
			QueueFree();
		}
	}

	private void OnScoreZoneEntered(Node body)
	{
		if (body is Player)
		{
			Hit?.Invoke(); 
			GD.Print("Player scored!");
		}
	}

	private void _on_body_entered(Node body)
	{
		if (body is Player)
		{
			Hit?.Invoke(); 
			GD.Print("Player hit the obstacle! tes");
		}
	}
}
