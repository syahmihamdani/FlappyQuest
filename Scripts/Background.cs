using Godot;

public partial class Background : ParallaxBackground
{
	const float SCROLL_SPEED = 100f;	//kecepatan background bergerak

	public override void _Ready()
	{

		//set parallax layer dengan node yang sesuai
		var parallaxLayer = GetNode<ParallaxLayer>("Background");
		if (parallaxLayer != null)
		{
			GD.Print("ParallaxLayer found!");
		}
		else
		{
			GD.Print("ParallaxLayer not found!");
		}
	}

	public override void _Process(double delta)
	{
		//proses scrollingnya
		ScrollOffset = new Vector2(ScrollOffset.X - SCROLL_SPEED * (float)delta, ScrollOffset.Y);
	}
}
