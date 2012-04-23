using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MindFusion.Diagramming;
using SavannaFrame.Classes;
using SolidBrush = MindFusion.Drawing.SolidBrush;

namespace SavannaFrame
{
    public partial class MainForm : Form
    {
        public Point StartLinkPoint, EndLinkPoint;
        
        public MainForm()
        {
            InitializeComponent();
            cmbTypeLink.SelectedIndex = 0;
            cmbZoom.SelectedIndex = 2;
            StartLinkPoint = new Point();
            EndLinkPoint = new Point();
            //List<Frame>
        }

        

        

        private void FraimDiagram_NodeCreated(object sender, MindFusion.Diagramming.NodeEventArgs e)
        {
            ShapeNode node = e.Node as ShapeNode;
            if (node != null)
            {
                AddFrameFrm frm = new AddFrameFrm();
                if (frm.ShowDialog()== DialogResult.OK)
                {
                    Frame frame = new Frame { FrameId = ClassFactory.kBase.GetMaxNodeId(), FrameName = frm.TextBox };
                    node.Id = frame.FrameId;
                    node.Text = frame.FrameName;
                    ClassFactory.kBase.AddFrame(frame);
                    TreeNode frameitem = new TreeNode { Text = frame.FrameName };
                    FrameTreeView.Nodes.Add(frameitem);
                }
            }


        }

        private void FrameDiagram_LinkCreated(object sender, LinkEventArgs e)
        {
            Frame frame = new Frame();
            Frame frame1 = new Frame(); 

            Frame frameUpper;// = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)e.Link.Destination.Id);
            Frame frameLower;
            string str = "";
            switch (cmbTypeLink.SelectedIndex)
            {
                case 0:
                    e.Link.Text = "Is_a";
                    e.Link.TextColor = Color.DarkRed;
                    e.Link.Pen.Color = Color.Red;
                    frameUpper = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)e.Link.Destination.Id);
                    frameLower = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)e.Link.Origin.Id);

                    //foreach (DiagramNode node in FrameDiagram.Nodes)
                    //{
                    //    if (node.GetBounds().Contains(StartLinkPoint.X, StartLinkPoint.Y))
                    //    {
                    //        if (cmbTypeLink.SelectedIndex == 0)
                    //        {
                    //            frame = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id);
                    //        }
                        
                    //        str = node.Id.ToString() + cmbTypeLink.SelectedItem.ToString();
                    //    }
                    //    if (node.GetBounds().Contains(EndLinkPoint.X, EndLinkPoint.Y))
                    //    {
                    //        frame1 = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id);
                    //    }

                    //}

                    //frame.IsA.ParentId = frame1.FrameId;
                    //frame.IsA.SlotDefault = frame1.FrameName;
                    //frame.IsA.frameId = frame1.FrameId;

                    frameLower.IsA.ParentId = frameUpper.FrameId;
                    frameLower.IsA.SlotDefault = frameUpper.FrameName;
                    frameLower.IsA.frameId = frameUpper.FrameId;
                    ClassFactory.kBase.AddIsA(frame); //простор для оптимизации
                    break;
                case 1:
                    e.Link.Text = "Sub";
                    e.Link.TextColor = Color.DarkBlue;
                    e.Link.Pen.Color = Color.Blue;

                    frameUpper = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)e.Link.Destination.Id);
                    frameLower = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)e.Link.Origin.Id);

                    //foreach (DiagramNode node in FrameDiagram.Nodes)
                    //{
                    //    if (node.GetBounds().Contains(StartLinkPoint.X, StartLinkPoint.Y))
                    //    {
                    //        if (cmbTypeLink.SelectedIndex == 0)
                    //        {
                    //            frame = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id);

                    //        }

                    //        str = node.Id.ToString() + cmbTypeLink.SelectedItem.ToString();
                    //    }
                    //    if (node.GetBounds().Contains(EndLinkPoint.X, EndLinkPoint.Y))
                    //    {
                    //        frame1 = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id);
                    //    }
                    //}

                    Slot slotSubframe = new Slot(){ IsSystem = false, frameId = frameLower.FrameId, ParentId = frameUpper.FrameId, SlotName="sub", SlotType = Classes.SlotType.Frame};
                    frameUpper.FrameSlots.Add(slotSubframe);
                    break;
            }


            

            
            //MessageBox.Show(str + str1);

        }

        private void diagramView_MouseDown(object sender, MouseEventArgs e)
        {
            if (FrameDiagram.Nodes.Count != 0)
            {
                StartLinkPoint.X = e.X;
                StartLinkPoint.Y = e.Y;
                toolStripLabel3.Text = "(" + StartLinkPoint.X + ":" + StartLinkPoint.Y + ")";
            }
        }

        private void diagramView_MouseUp(object sender, MouseEventArgs e)
        {
            EndLinkPoint.X = e.X;
            EndLinkPoint.Y = e.Y;
            toolStripLabel4.Text = "(" + EndLinkPoint.X + ":" + EndLinkPoint.Y + ")";

            // двигаем вершину и передаем координаты в фрейм
            foreach (ShapeNode node in FrameDiagram.Nodes)
            {
                if (node.GetBounds().Contains(e.X, e.Y))
                {
                    Frame frame = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id);
                    frame.X = e.X;
                    frame.Y = e.Y;
                }
            }
        }


        private void FrameDiagram_NodeDeleting(object sender, NodeValidationEventArgs e)
        {
            ClassFactory.kBase.DeleteFrame(FrameTreeView.SelectedNode.Text);
            FrameTreeView.Nodes.Remove(FrameTreeView.SelectedNode);
            TreeViewBinding();
        }

        private void FrameDiagram_NodeSelected(object sender, NodeEventArgs e)
        {
            //foreach (DiagramNode node1 in FrameDiagram.Nodes)
            //    node1.Brush = new SolidBrush(Color.PowderBlue);
            e.Node.Brush = new SolidBrush(Color.Pink);
            List<Frame> frmlst = ClassFactory.kBase.FrameList();
            Frame frm = frmlst.Find(f => f.FrameId == (int)e.Node.Id);
            ClassFactory.SelectedObjId = (int) e.Node.Id;
            foreach (TreeNode tn in FrameTreeView.Nodes)
            {
                if (tn.Text == frm.FrameName)
                    FrameTreeView.SelectedNode = tn;
            }
            SlotDataBinding((int) e.Node.Id);

        }

        private void FrameDiagram_NodeDeselected(object sender, NodeEventArgs e)
        {
            foreach (DiagramNode node1 in FrameDiagram.Nodes)
                node1.Brush = new SolidBrush(Color.PowderBlue);
        }

        private void FrameTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //FrameDataGridView.DataSource = ClassFactory.kBase.EditGridSlots(e.Node.Text);
            List<Frame> frmlst = ClassFactory.kBase.FrameList();
            Frame frm = frmlst.Find(f => f.FrameName == e.Node.Text);
            foreach (DiagramNode node in FrameDiagram.Nodes)
            {
                if ((int) node.Id == frm.FrameId)
                {
                    foreach (DiagramNode node1 in FrameDiagram.Nodes)
                        node1.Brush = new SolidBrush(Color.PowderBlue);
                    node.Brush = new SolidBrush(Color.Pink);
                }   
            }
            SlotDataBinding(frm.FrameId);
        }

        private void SlotDataBinding(int frId)
        {
            FrameDataGridView.Rows.Clear();
            List<Slot> lss = ClassFactory.kBase.SlotList(frId);
            foreach (Slot slot in lss)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                cell1.Value = slot.SlotName;
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = slot.SlotType;
                DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                cell3.Value = slot.SlotDefault;

                row.Cells.AddRange(cell1,cell2,cell3);
                FrameDataGridView.Rows.Add(row);
            }
        }

        private void cmbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbZoom.SelectedIndex)
            {
                case 0:
                    diagramView.ZoomFactor = 50;
                    break;
                case 1:
                    diagramView.ZoomFactor = 75;
                    break;
                case 2:
                    diagramView.ZoomFactor = 100;
                    break;
                case 3:
                    diagramView.ZoomFactor = 125;
                    break;
                case 4:
                    diagramView.ZoomFactor = 150;
                    break;
            }
        }

        // закидываем создаем новый фрейм и отображаем
        private void добавитьФреймшаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFrameFrm frm = new AddFrameFrm();
            if (frm.ShowDialog()== DialogResult.OK)
            {
                Random rand = new Random();
                Frame frame = new Frame { FrameId = ClassFactory.kBase.GetMaxNodeId(1), FrameName = frm.TextBox };
                //frame.FrameSlots.Add(new Slot { SlotName = "slot" + ClassFactory.kBase.GetMaxSlotId(1), SlotId = 0, SlotInheritance = SlotInherit.Override, SlotType = Classes.SlotType.Integer });
                //frame.FrameSlots.Add(new Slot { SlotName = "slo1t" + ClassFactory.kBase.GetMaxSlotId(1), SlotId = 1, SlotInheritance = SlotInherit.Same, SlotType = Classes.SlotType.Frame });
                ShapeNode node = new ShapeNode { Text = frame.FrameName, Id = frame.FrameId, Brush = new SolidBrush(Color.PowderBlue), Shape = Shapes.Ellipse };
                node.SetBounds(new RectangleF(new PointF(rand.Next(100, 400), rand.Next(100, 400)), new SizeF(100, 30)), true, true);
                node.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                node.TextFormat.Alignment = StringAlignment.Center;
                node.TextFormat.LineAlignment = StringAlignment.Center;
                ClassFactory.isSaved = false;
                frame.X = node.GetBounds().X;
                frame.Y = node.GetBounds().Y;
                FrameDiagram.Nodes.Add(node);
                ClassFactory.kBase.AddFrame(frame);
                TreeNode frameitem = new TreeNode { Text = frame.FrameName };
                FrameTreeView.Nodes.Add(frameitem);
            }
            
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Когнитивная Игра - Саванна", "О программе");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "(KnowLedgeBase Files *.knb)|*.knb";
            svf.Title = "Сохранить базу знаний";
            svf.InitialDirectory = Assembly.GetExecutingAssembly().Location;
            if (svf.ShowDialog() == DialogResult.OK)
            {
                ClassFactory.SaveKBase(svf.FileName);
                //MessageBox.Show("База знаний успешно сохранена!!!!", "Информация",
                //   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(KnowLedgeBase Files *.knb)|*.knb";
            ofd.Title = "Открыть базу знаний";
            ofd.InitialDirectory = Assembly.GetExecutingAssembly().Location;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ClassFactory.LoadKBase(ofd.FileName);
            }
            TreeViewBinding();
            DrawDiagram();
        }

        ShapeNode findNodeById(int id)
        {
            ShapeNode result = null;
            foreach (ShapeNode node in FrameDiagram.Nodes)
                if (((int)node.Id) == id)
                {
                    result = node;
                    break;
                }
            return result;
        }

        // отрисовка диаграммы
        private void DrawDiagram()
        {
            FrameDiagram.ClearAll();
            List<Frame> curList = ClassFactory.kBase.FrameList();
            foreach (Frame frm in curList)
            {
                // рисование вершин
                ShapeNode node = new ShapeNode { Text = frm.FrameName, Id = frm.FrameId, Brush = new SolidBrush(Color.PowderBlue), Shape = Shapes.Ellipse };
                node.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                node.TextFormat.Alignment = StringAlignment.Center;
                node.TextFormat.LineAlignment = StringAlignment.Center;
                node.SetBounds(new RectangleF(new PointF(frm.X, frm.Y), new SizeF(100, 30)), true, true);
                FrameDiagram.Nodes.Add(node);

                //if (frm.IsA != null)
                //{
                //    DiagramNode from, destination;
                //    from=
                //    DiagramLink link=new DiagramLink(FrameDiagram, origin, destination);

                //    //FrameDiagram.Links.Add(
                //}

            }

            foreach (Frame frm in curList)
            {
                foreach (Slot slot in frm.FrameSlots)
                    if (slot.SlotType == Classes.SlotType.Frame)
                    {
                        //значит, это субфрейм. Надо нарисовать дугу :)
                        ShapeNode nodeSubframe = findNodeById(slot.frameId);
                        ShapeNode nodeMainFrame = findNodeById(frm.FrameId);
                        DiagramLink link = new DiagramLink(FrameDiagram, nodeSubframe, nodeMainFrame);
                        link.Text = "Sub";
                        link.TextColor = Color.DarkBlue;
                        link.Pen.Color = Color.Blue;
                        FrameDiagram.Links.Add(link);
                    }
            }

            //link.HeadShape = FrameDiagram.Nodes[1];
            foreach (ShapeNode node in FrameDiagram.Nodes)
            {
                Frame from = ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id);
                if (from.IsA != null)
                {
                    if (from.IsA.frameId != -1)
                    {
                        ShapeNode nodeTo = null;
                        int idTo = from.IsA.frameId;

                        foreach (ShapeNode innerNode in FrameDiagram.Nodes)
                            if (((int)innerNode.Id) == idTo)
                            {
                                nodeTo = innerNode;
                                break;
                            }
                        DiagramLink link = new DiagramLink(FrameDiagram, node, nodeTo);
                        link.Text = "Is_a";
                        link.TextColor = Color.DarkRed;
                        link.Pen.Color = Color.Red;
                        FrameDiagram.Links.Add(link);
                    }
                }
                //if (node.GetBounds().Contains(e.X, e.Y))
                //{
                //    ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id).X = e.X;
                //    ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id).Y = e.Y;
                //}
            }
            //FrameDiagram.Links.

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClassFactory.isSaved)
            {
                var dr = MessageBox.Show("Сохранить базу знаний?", "Информация",
                                         MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    ClassFactory.SaveKBase();
                    return;
                }
                else
                {
                    if (dr == DialogResult.Cancel) return;    
                }
                
            }
            ClassFactory.NewKnBase();
            FrameDiagram.Nodes.Clear();
            FrameDiagram.Links.Clear();
            MessageBox.Show("Новая база знаний создана успешно! Теперь пополните её...", "Сообщение");
            TreeViewBinding();
        }

        private void TreeViewBinding()
        {
            FrameTreeView.Nodes.Clear();
            List<Frame> frm = ClassFactory.kBase.FrameList();
            foreach (Frame frame in frm)
            {
                TreeNode frameitem = new TreeNode { Text = frame.FrameName };
                FrameTreeView.Nodes.Add(frameitem);
            }
        }

        private void удалитьФреймToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode dn = FrameTreeView.SelectedNode;
            DiagramNode ddn = null;
            FrameTreeView.Nodes.Remove(dn);
            foreach (DiagramNode node in FrameDiagram.Nodes)
            {
                if (node.Id.ToString() == dn.Text.Substring(5))
                    ddn = node;
            }
            FrameDiagram.Nodes.Remove(ddn);
        }

        private void FrameTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            List<Frame> frmlst = ClassFactory.kBase.FrameList();
            Frame frm = frmlst.Find(f => f.FrameName == FrameTreeView.SelectedNode.Text);
            foreach (DiagramNode node in FrameDiagram.Nodes)
            {
                if ((int) node.Id == frm.FrameId)
                {
                    foreach (DiagramNode node1 in FrameDiagram.Nodes)
                        node1.Brush = new SolidBrush(Color.PowderBlue);
                    node.Brush = new SolidBrush(Color.Pink);
                }
            }

        }

        private void FrameTreeView_KeyUp(object sender, KeyEventArgs e)
        {
            List<Frame> frmlst = ClassFactory.kBase.FrameList();
            Frame frm = frmlst.Find(f => f.FrameName == FrameTreeView.SelectedNode.Text);
            foreach (DiagramNode node in FrameDiagram.Nodes)
            {
                if ((int)node.Id == frm.FrameId)
                {
                    foreach (DiagramNode node1 in FrameDiagram.Nodes)
                        node1.Brush = new SolidBrush(Color.PowderBlue);
                    node.Brush = new SolidBrush(Color.Pink);
                }
            }
        }

        private void FrameDiagram_SelectionMoved(object sender, EventArgs eventArgs)
        {
            
            //foreach (ShapeNode node in FrameDiagram.Nodes)
            //{
            //    if (node.GetBounds().Contains(x,y))
            //    {
            //        ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int) node.Id).X = x;
            //        ClassFactory.kBase.FrameList().Find(f => f.FrameId == (int)node.Id).Y = y;
            //    }
            //}
        }

        private void diagramView_MouseMove(object sender, MouseEventArgs e)
        {
            //x = e.X;
            //y = e.Y;
        }

        private void FrameDiagram_NodeDeleted(object sender, NodeEventArgs e)
        {
            int idToDel=((int)e.Node.Id);
            foreach (Frame frame in ClassFactory.kBase.FrameList())
            {
                if (frame.IsA.frameId == idToDel)
                    frame.IsA.frameId = -1;
                List<Slot> slotsToDel=new List<Slot>();
                foreach (Slot slot in frame.FrameSlots)
                    if (slot.frameId == idToDel)
                        slotsToDel.Add(slot);
                foreach (Slot slot in slotsToDel)
                    frame.FrameSlots.Remove(slot);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
