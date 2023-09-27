using Godot;
using System;

public partial class worldGen : Node3D
{
    public override void _Ready()
    {

        FastNoiseLite noise = new();
        noise.FractalOctaves = 6;
        noise.NoiseType = FastNoiseLite.NoiseTypeEnum.Perlin;

        MeshInstance3D test = GetNode<MeshInstance3D>("worldMesh");
        PlaneMesh plane = (PlaneMesh)test.Mesh;
        plane.Size = new Vector2(400,400);
        plane.SubdivideDepth = 200;
        plane.SubdivideWidth = 200;

        SurfaceTool surface_tool = new SurfaceTool();
        surface_tool.CreateFrom(plane,0);

        ArrayMesh array_mesh = surface_tool.Commit();

        MeshDataTool mesh_data_tool = new MeshDataTool();
        mesh_data_tool.CreateFromSurface(array_mesh,0);


        for(int i=0; i<mesh_data_tool.GetVertexCount(); i++){
            Vector3 vertex = mesh_data_tool.GetVertex(i);
            vertex.Y = noise.GetNoise3D(vertex.X,vertex.Y, vertex.Z)*60;
            mesh_data_tool.SetVertex(i,vertex);
        }

        array_mesh.ClearSurfaces();

        mesh_data_tool.CommitToSurface(array_mesh);
        surface_tool.Begin(Mesh.PrimitiveType.Triangles);
        surface_tool.CreateFrom(array_mesh,0);
        surface_tool.GenerateNormals();


        //MeshInstance3D world = new MeshInstance3D();
        test.Mesh = surface_tool.Commit();
        


        //AddChild(world);
        test.CreateTrimeshCollision();
        //GD.Print(world.GetChildren()[0].GetChildren());
        

    }

    public override void _Process(double delta)
	{
	}
}
