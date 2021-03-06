﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

using Point = System.Drawing.Point;

namespace Moonfish.Graphics
{
    public partial class MarkerViewer : Form
    {
        private DynamicScene Scene { get; set; }
        private CacheStream Map { get; set; }
        private TagIdent SelectedTag { get; set; }

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

        private static bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, 0, 0, 0) == 0;
        }

        public MarkerViewer()
        {
            InitializeComponent();
            glControl1.Load += glControl1_Load;

            //foreach ( var value in Enum.GetValues( typeof( TransformMode ) ) )
            //{
            //    toolStripComboBox1.Items.Add( value );
            //}
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void SaveMarkerData()
        {
            //var selectedItem = Scene.ObjectManager[SelectedTag];
            //var renderModel = selectedItem.Model.RenderModel.Get<RenderModelBlock>();

            //if (selectedItem == null) return;

            //var markerEnumerator =
            //    renderModel.MarkerGroups.SelectMany(x => x.Markers).GetEnumerator();

            //BinaryReader binaryReader = new BinaryReader(Map);
            //BinaryWriter binaryWriter = new BinaryWriter(Map);

            //Map.Seek(selectedItem.Model.RenderModel.Ident);
            //Map.Seek(88, SeekOrigin.Current);
            //var markerGroups = binaryReader.ReadBlamPointer(12);
            //foreach (var group in markerGroups)
            //{
            //    Map.Seek(group + 4, SeekOrigin.Begin);
            //    var markers = binaryReader.ReadBlamPointer(36);
            //    foreach (var marker in markers)
            //    {
            //        if (!markerEnumerator.MoveNext()) return;
            //        var data = markerEnumerator.Current;
            //        Map.Seek(marker + 4, SeekOrigin.Begin);
            //        binaryWriter.Write(data.Translation);
            //        binaryWriter.Write(data.Rotation);
            //        binaryWriter.Write(data.Scale);
            //    }
            //}
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            Scene = new DynamicScene();
            Application.Idle += HandleApplicationIdle;
            Scene.OnFrameReady += Scene_OnFrameReady;

            glControl1.Resize += glControl1_Resize;
            glControl1.MouseDown += Scene.Camera.OnMouseDown;
            glControl1.MouseMove += Scene.Camera.OnMouseMove;
            glControl1.MouseUp += Scene.Camera.OnMouseUp;
            glControl1.MouseCaptureChanged += Scene.Camera.OnMouseCaptureChanged;

            glControl1.MouseDown += Scene.OnMouseDown;
            glControl1.MouseMove += Scene.OnMouseMove;
            glControl1.MouseUp += Scene.OnMouseUp;


            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera
            glControl1_Resize(this, new EventArgs());
        }

        private void LoadMap(string fileName)
        {
            Map = new CacheStream(fileName);

            listBox1.Items.Clear();
            listBox1.Items.AddRange(Map.Index.Where(x => x.Class.ToString() == "hlmt").Select(x => (object) x).ToArray());
            listBox1.DisplayMember = "Path";
            listBox1.SelectedIndex = listBox1.Items.Count > 0 ? 0 : -1;
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            ChangeViewport(glControl1.Width, glControl1.Height);
            glControl1.Invalidate();
        }

        private void ChangeViewport(int width, int height)
        {
            Scene.Camera.Viewport.Size = new Size(width, height);
        }

        private void Scene_OnFrameReady(object sender, EventArgs e)
        {
            glControl1.SwapBuffers();
            UpdateState();
        }

        private class FloatingLabel : Label
        {
            protected override void WndProc(ref Message m)
            {
                const int WM_NCHITTEST = 0x0084;
                const int HTTRANSPARENT = (-1);

                if (m.Msg == WM_NCHITTEST)
                {
                    m.Result = (IntPtr) HTTRANSPARENT;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }

        private void UpdateState()
        {
            //foreach (FloatingLabel control in glControl1.Controls)
            //{
            //    control.Visible = tsBtnLabels.Checked;
            //    var marker = (MarkerWrapper) control.Tag;
            //    var location = Scene.Camera.Project( marker.ParentWorldMatrix.ExtractTranslation( ) );
            //    control.Location = new Point((int) location.X, (int) location.Y);
            //}
            //Scene.DrawDebugCollision = debugDrawToolStripMenuItem.Checked;
            ////Scene.MousePole.Mode = (TransformMode)Enum.Parse(typeof(TransformMode), toolStripComboBox1.SelectedItem.ToString());
            //var selectedItem = Scene.ObjectManager[SelectedTag];
            //if (selectedItem == null) return;
            //selectedItem.Flags = toolStripButton1.Checked
            //    ? selectedItem.Flags |= ScenarioObject.RenderFlags.RenderNodes
            //    : selectedItem.Flags &= ~ScenarioObject.RenderFlags.RenderNodes;
            //selectedItem.Flags = toolStripButton2.Checked
            //    ? selectedItem.Flags |= ScenarioObject.RenderFlags.RenderMarkers
            //    : selectedItem.Flags &= ~ScenarioObject.RenderFlags.RenderMarkers;
            //selectedItem.Flags = toolStripButton3.Checked
            //    ? selectedItem.Flags |= ScenarioObject.RenderFlags.RenderMesh
            //    : selectedItem.Flags &= ~ScenarioObject.RenderFlags.RenderMesh;
            //lblRenderTime.Text = string.Format(lblRenderTime.Tag.ToString(),
            //    TimeSpan.FromTicks((long) Scene.Performance.FrameTime).TotalMilliseconds);
        }


        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Scene.Update(0f, 0f);
                Scene.RenderFrame(0f);
            }
        }

        private void RemoveModel(TagIdent ident)
        {
            //var @object = Scene.ObjectManager[ident];
            //if (@object == null) return;

            //var collisionObject =
            //    Scene.CollisionManager.World.CollisionObjectArray.FirstOrDefault(x => x == @object.CollisionObject);
            //if (collisionObject != null)
            //{
            //    Scene.CollisionManager.World.RemoveCollisionObject(@object.CollisionObject);
            //}
            //glControl1.Controls.Clear();
            //foreach (var marker in @object.Markers)
            //{
            //    var markerCollisionObject =
            //        Scene.CollisionManager.World.CollisionObjectArray.FirstOrDefault(x => x.UserObject == marker);
            //    if (markerCollisionObject != null)
            //    {
            //        Scene.CollisionManager.World.RemoveCollisionObject(markerCollisionObject);
            //    }
            //}
            //Scene.ObjectManager.Remove(ident);
        }

        private void LoadModel(TagIdent ident)
        {
            //var model = (ModelBlock) (Map.Deserialize(ident));
            //var renderModel = model.RenderModel.Get<RenderModelBlock>();

            //var scenarioObject = new ScenarioObject(model);
            //Scene.ObjectManager.Add(ident, scenarioObject);

            ////Scene.ProgramManager.LoadMaterials(renderModel.Materials.Select(x => x.Shader.Ident), Map);
            //Scene.CollisionManager.LoadScenarioObjectCollision(Scene.ObjectManager[ident]);

            //var @object = Scene.ObjectManager[ident];

            //propertyGrid1.SelectedObject = renderModel.MarkerGroups;
            //glControl1.Controls.Clear();
            //foreach (var markerGroup in renderModel.MarkerGroups)
            //{
            //    var name = markerGroup.Name.ToString();
            //    foreach (var marker in markerGroup.Markers)
            //    {
            //        glControl1.Controls.Add(
            //            new FloatingLabel
            //            {
            //                Text = name,
            //                BackColor = Color.Red,
            //                ForeColor = Color.Black,
            //                AutoSize = true,
            //                Tag = marker
            //            });
            //    }
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex < 0) return;
            //RemoveModel(SelectedTag);
            //SelectedTag = ((TagInfo) listBox1.SelectedItem).tagDatum.Identifier;
            //if (Scene.ObjectManager[SelectedTag] != null)
            //{
            //    LoadModel(SelectedTag);
            //}
        }

        private void glControl1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Update(0f, 0f);
            Scene.RenderFrame(0f);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMarkerData();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "(*.map)|map file",
                Multiselect = false
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            LoadMap(dialog.FileName);
        }
    }
}