using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.WinForms;
using OpenTK_WinForms_Template;

namespace OpenTK_WinForms_2D_Game.source
{
    internal class Box
    {
        int vao;
        Shader shader;

        public Vector2 position;
        public float width { get; private set; }
        public float height { get; private set; }
        public float halfWidth { get; private set; }
        public float halfHeight { get; private set; }

        public Box(float width, float height, float posX, float posY)
        {
            this.width = width;
            this.height = height;
            halfWidth = width / 2;
            halfHeight = height / 2;

            position = new Vector2(posX, posY);

            SetupVertices(width, height);

            shader = new Shader("shaders/vert.vert", "shaders/frag.frag");
        }

        void SetupVertices(float width, float height)
        {
            // Define the vertices of the box
            float[] vertices =
            {
                -halfWidth, -halfHeight, 1.0f,  // bottom-left
                 halfWidth, -halfHeight, 1.0f,  // bottom-right
                 halfWidth,  halfHeight, 1.0f,  // top-right
                -halfWidth,  halfHeight, 1.0f  // top-left
            };

            // Define the indices that form the triangles of the box
            uint[] indices =
            {
                0, 1, 2,  // first triangle
                2, 3, 0   // second triangle
            };

            // Generate and bind the vertex buffer
            int vertexBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // Generate and bind the index buffer
            int indexBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            // Generate and bind the vertex array object (VAO)
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
        }

        public void Draw(GLControl glControl)
        {
            shader.Use();

            // Create the model matrix for the box
            Matrix4 model = Matrix4.CreateTranslation(position.X, position.Y, 0.0f);

            // Create the projection matrix for the scene
            float aspectRatio = (float)glControl.Width / glControl.Height;
            Matrix4 projection = Matrix4.CreateOrthographicOffCenter(-aspectRatio, aspectRatio, -1f, 1f, -1f, 1f);

            // Set the model and projection matrices in the shader
            GL.UniformMatrix4(0, false, ref model);
            GL.UniformMatrix4(1, false, ref projection);

            // Bind the vertex array object (VAO) and draw the box
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
        }
    }
}