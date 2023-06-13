#nullable disable  // Disables nullability warnings
using OpenTK.WinForms;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;
using OpenTK_WinForms_2D_Game.source;

namespace OpenTK_WinForms_Template
{
    public partial class MainForm : Form
    {
        GLControl glControl;
        Shader basicShader;

        Stopwatch deltaTimeStopwatch;
        float elapsedTime;

        float stepTime;
        float stepSize = 0.25f;

        Box playerBox;
        Box obstacleBox;

        float verticalVelocity;
        float gravity = -9.0f;

        int score, highScore;


        public MainForm()
        {
            InitializeComponent();
        }

        void OnFormLoad(object sender, EventArgs e)
        {
            // Create and configure the GLControl
            glControl = new GLControl();
            glControl.Load += OnLoad;
            glControl.Paint += OnRender;
            glControl.KeyDown += OnKeyPress;

            // Parent the GLControl context to the panel
            glControl.Dock = DockStyle.Fill;
            glParentPanel.Controls.Add(glControl);

            deltaTimeStopwatch = Stopwatch.StartNew();

            GL.Viewport(0, 0, glControl.Width, glControl.Height);

        }

        void OnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.Black);

            playerBox = new Box(0.15f, 0.15f, 0.0f, 0.0f);
            obstacleBox = new Box(0.1f, 0.2f, 1.5f, 0.025f);
        }

        void Update(float deltaTime)
        {
            glControl.Focus();

            HandleObstacleMovement(deltaTime);
            HandlePlayerMovement(deltaTime);
            HandlePlayerCollision();
        }

        void FixedUpdate()
        {
            score += 1;
            scoreLabel.Text = "Score: " + score.ToString();
        }

        void OnRender(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            playerBox.Draw(glControl);
            obstacleBox.Draw(glControl);
            glControl.SwapBuffers();
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            float deltaTime = (float)deltaTimeStopwatch.Elapsed.TotalSeconds;
            deltaTimeStopwatch.Restart();

            elapsedTime += deltaTime;

            Update(deltaTime);

            if (elapsedTime > stepTime + stepSize)
            {
                FixedUpdate();
                stepTime = elapsedTime;
            }

            glControl.Invalidate();
        }

        void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (playerBox.position.Y - playerBox.halfHeight <= 0.1f)
                {
                    verticalVelocity = 3.0f;
                }
            }
        }

        void HandlePlayerMovement(float deltaTime)
        {
            if (playerBox.position.Y - playerBox.halfHeight < 0.0f && verticalVelocity < 0.0f)
            {
                playerBox.position.Y = 0.0f;
                verticalVelocity = 0.0f;
            }
            else
            {
                verticalVelocity += gravity * deltaTime;
            }

            playerBox.position.Y += verticalVelocity * deltaTime;
        }

        void HandleObstacleMovement(float deltaTime)
        {
            if (obstacleBox.position.X <= -1.5f)
            {
                obstacleBox.position.X = 1.5f;
            }
            obstacleBox.position.X -= (1.0f + (score * 0.001f)) * deltaTime;
        }

        void HandlePlayerCollision()
        {
            if (playerBox.position.X + playerBox.halfWidth > obstacleBox.position.X - obstacleBox.halfWidth && playerBox.position.X - playerBox.halfWidth < obstacleBox.position.X + obstacleBox.halfWidth)
            {
                if (playerBox.position.Y - playerBox.halfHeight < obstacleBox.position.Y + obstacleBox.halfHeight)
                {
                    GameOver();
                }
            }
        }

        void GameOver()
        {
            obstacleBox.position.X = 1.5f;
            playerBox.position.Y = 0.0f;

            if (score > highScore)
            {
                highScore = score;
                highScoreLabel.Text = "High Score: " + highScore.ToString();
            }

            score = 0;
        }
    }
}