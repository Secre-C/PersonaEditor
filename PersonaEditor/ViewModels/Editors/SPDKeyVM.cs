using PersonaEditorLib.SpriteContainer;
using AuxiliaryLibraries.WPF;
using PersonaEditor.Classes;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace PersonaEditor.ViewModels.Editors
{
    class SPDKeyVM : BindingObject
    {
        SPDKey Key;

        private bool _IsSelected = false;

        public string Name => Encoding.GetEncoding("shift-jis").GetString(Key.Comment.Where(x => x != 0x00).ToArray());

        public int ID
        {
            get { return Key.ListIndex; }
            set
            {
                if (value != Key.ListIndex)
                {
                    Key.ListIndex = value;
                    Notify("ID");
                }
            }
        }
        public int X1
        {
            get { return Key.X0; }
            set
            {
                if (value != Key.X0)
                {
                    Key.X0 = value;
                    Notify("X1");
                    Notify("Rect");
                }
            }
        }
        public int X2
        {
            get { return Key.Xdel; }
            set
            {
                if (value != Key.Xdel)
                {
                    Key.Xdel = value;
                    Notify("X2");
                    Notify("Rect");
                }
            }
        }
        public int Y1
        {
            get { return Key.Y0; }
            set
            {
                if (value != Key.Y0)
                {
                    Key.Y0 = value;
                    Notify("Y1");
                    Notify("Rect");
                }
            }
        }
        public int Y2
        {
            get { return Key.Ydel; }
            set
            {
                if (value != Key.Ydel)
                {
                    Key.Ydel = value;
                    Notify("Y2");
                    Notify("Rect");
                }
            }
        }
        public int X3
        {
            get { return Key.XScl; }
            set
            {
                if (value != Key.XScl)
                {
                    Key.XScl = value;
                    Notify("X3");
                }
            }
        }
        public int Y3
        {
            get { return Key.YScl; }
            set
            {
                if (value != Key.YScl)
                {
                    Key.YScl = value;
                    Notify("Y3");
                }
            }
        }

        public Rect Rect
        {
            get { return new Rect(new Point(X1, Y1), new Point(X2 + X1, Y2 + Y1)); }
        }

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    Notify("IsSelected");
                }
            }
        }

        public SPDKeyVM(SPDKey key)
        {
            Key = key ?? throw new ArgumentNullException("key");
        }
    }
}