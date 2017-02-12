using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Moonfish.Cache;
using Point = System.Drawing.Point;

namespace Moonfish.Graphics
{
    public partial class ShaderViewer : Form
    {
        private Scene Scene { get; set; }
        private CacheStream Map { get; set; }

        #region Peek Message Native

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax,
            uint remove);

        #endregion

        private bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint) 0, (uint) 0, (uint) 0) == 0;
        }

        public ShaderViewer()
        {
            InitializeComponent();
            glControl1.Load += glControl1_Load;
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            //Scene = new Scene();
            //Application.Idle += HandleApplicationIdle;
            //Scene.OnFrameReady += Scene_OnFrameReady;

            //glControl1.Resize += glControl1_Resize;
            //glControl1.MouseDown += Scene.Camera.OnMouseDown;
            //glControl1.MouseMove += Scene.Camera.OnMouseMove;
            //glControl1.MouseUp += Scene.Camera.OnMouseUp;
            //glControl1.MouseCaptureChanged += Scene.Camera.OnMouseCaptureChanged;

            //var fileName = Path.Combine(Local.MapsDirectory, "headlong.map");
            //var directory = Path.GetDirectoryName(fileName);
            //var maps = Directory.GetFiles(directory, "*.map", SearchOption.TopDirectoryOnly);
            //var resourceMaps = maps.GroupBy(
            //    x => { return Halo2.CheckMapType(x); }
            //    ).Where(x => x.Key == MapType.MainMenu
            //                 || x.Key == MapType.Shared
            //                 || x.Key == MapType.SinglePlayerShared)
            //    .Select(g => g.First()).ToList();
            //resourceMaps.ForEach(x => Halo2.LoadResource(new CacheStream(x)));
            //Map = new CacheStream(fileName);

            //var ident = Map.Index.Where((TagClass)"hlmt", "masterchief").First().Identifier;
            //Map.Deserialize(ident);
            //var model = (ModelBlock) Map.Deserialize(ident);
            //int width = 1, height = 1;
            //for (int i = 0; i < width*height; ++i)
            //{
            //    float x = 0.4f*(i%width);
            //    float y = 0.4f*(i/width);
            //    var scenarioObject = new ScenarioObject(model)
            //    {
            //        WorldMatrix = Matrix4.CreateTranslation(new Vector3(x, y, 0))
            //    };
            //    Scene.ObjectManager.Add(ident, scenarioObject);
            //}

            //var shaderTags = Map.Index.Where(x => x.Class.ToString() == "shad").ToArray();
            //listBox1.Items.AddRange(shaderTags.Select(x => (object) x.Path).ToArray());
            //listBox1.DisplayMember = "Path";

            //listBox1.SelectedIndex = listBox1.FindString(@"objects\characters\masterchief\shaders\masterchief");

            ////  firing this method is meant to load the view-projection matrix values into 
            ////  the shader uniforms, and initalizes the camera
            //glControl1_Resize(this, new EventArgs());
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            ChangeViewport(glControl1.Width, glControl1.Height);
        }

        private void ChangeViewport(int width, int height)
        {
            Scene.Camera.Viewport.Size = new Size(width, height);
        }

        private void Scene_OnFrameReady(object sender, EventArgs e)
        {
            Text = string.Format("{0:###0.00}ms",
                TimeSpan.FromTicks((long) Scene.Performance.FrameTime).TotalMilliseconds);
            glControl1.SwapBuffers();
        }

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Scene.Update(0f, 0f);
                Scene.RenderFrame(0f);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            var selectedShaderTag = (listBox1.SelectedItem as TagInfo);
            LoadShader(selectedShaderTag);
        }

        private MaterialShader material;

        private void LoadShader(TagInfo selectedShaderTag)
        {
            //var shader = Map.Deserialize(selectedShaderTag.tagDatum.Identifier) as ShaderBlock;

            //ShaderPostprocessBitmapNewBlock[] textures;
            //material = new MaterialShader(shader, Map, out textures);
            //listBox2.Items.Clear();
            //listBox2.Items.AddRange(material.shaderPassPaths);
            //listBox2.SelectedIndex = 0;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            material.UsePass(listBox2.SelectedIndex, null);
        }
    }
}