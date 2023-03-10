using UnityEngine;

namespace TestTasks.Task_0_ProceduralGeometry.Scripts.MeshCreators
{
    public class PlaneMeshCreator : IMeshCreator
    {
        private readonly int _height;
        private readonly int _width;

        public PlaneMeshCreator(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
        public Mesh Create()
        {
            Mesh mesh = new Mesh();
            
            Vector3[] vertices = new Vector3[(_width + 1) * (_height + 1)];

            int i = 0;
            for (int d = 0; d <= _height; d++)
            {
                for (int w = 0; w <= _width; w++)
                {
                    vertices[i] = new Vector3(w, 0, d) - new Vector3(_width / 2f, 0, _height / 2f);
                    i++;
                }
            }
            
            int[] triangles = new int[_width * _height * 2 * 3]; 

            for (int h = 0; h < _height; h++)
            {
                for (int w = 0; w < _width; w++)
                {
                    int ti = (h * (_width) + w) * 6; 

                    
                    triangles[ti] = (h * (_width + 1)) + w;
                    triangles[ti + 1] = ((h + 1) * (_width + 1)) + w;
                    triangles[ti + 2] = ((h + 1) * (_width + 1)) + w + 1;
                    
                    triangles[ti + 3] = (h * (_width + 1)) + w;
                    triangles[ti + 4] = ((h + 1) * (_width + 1)) + w + 1;
                    triangles[ti + 5] = (h * (_width + 1)) + w + 1;
                }
            }
            
            Vector2[] uv = new Vector2[(_width + 1) * (_height + 1)];

            i = 0;
            for (int h = 0; h <= _height; h++)
            {
                for (int w = 0; w <= _width; w++)
                {
                    uv[i] = new Vector2(w / (float)_width, h / (float)_height);
                    i++;
                }
            }
            
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;

            return mesh;
        }
    }
}