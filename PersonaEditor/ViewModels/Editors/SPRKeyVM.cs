using System;
using System.Windows;
using AuxiliaryLibraries.WPF;
using PersonaEditor.ApplicationSettings;
using PersonaEditorLib.SpriteContainer;

namespace PersonaEditor.ViewModels.Editors
{
    class SPRKeyVM : BindingObject
    {
        SPRKey Key;

        private bool _IsSelected = false;

        public string Name
        {
            get { return Key.Comment; }
        }

        public int X1
        {
            get { return Key.X1*SPREditor.Default.Scale; }
            set
            {
                if (value != Key.X1)
                {
                    Key.X1 = value / SPREditor.Default.Scale;
                    Notify("X1");
                    Notify("Rect");
                }
            }
        }

        public int X2
        {
            get { return Key.X2 * SPREditor.Default.Scale; }
            set
            {
                if (value != Key.X2)
                {
                    Key.X2 = value / SPREditor.Default.Scale;
                    Notify("X2");
                    Notify("Rect");
                }
            }
        }

        public int Y1
        {
            get { return Key.Y1 * SPREditor.Default.Scale; }
            set
            {
                if (value != Key.Y1)
                {
                    Key.Y1 = value / SPREditor.Default.Scale;
                    Notify("Y1");
                    Notify("Rect");
                }
            }
        }
        public int Y2
        {
            get { return Key.Y2 * SPREditor.Default.Scale; }
            set
            {
                if (value != Key.Y2)
                {
                    Key.Y2 = value / SPREditor.Default.Scale;
                    Notify("Y2");
                    Notify("Rect");
                }
            }
        }

        public bool XFlip
        {
            get { return Key.RotMask.HorizontalFlip; }
            set
            {
                if (value != Key.RotMask.HorizontalFlip)
                {
                    Key.RotMask.HorizontalFlip = value;
                    Notify("XFlip");
                }
            }
        }

        public bool YFlip
        {
            get { return Key.RotMask.VerticalFlip; }
            set
            {
                if (value != Key.RotMask.VerticalFlip)
                {
                    Key.RotMask.VerticalFlip = value;
                    Notify("YFlip");
                }
            }
        }

        public int TextureID
        {
            get { return Key.TextureIndex; }
        }

        public int ID
        {
            get { return Key.Index; }
        }


        public Rect Rect
        {
            get { return new Rect(new Point(X1, Y1), new Point(X2, Y2)); }
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

        public SPRKeyVM(SPRKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Key = key;
            SPREditor.Default.PropertyChanged += SettingChanged;
        }

        private void SettingChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Scale")
                return;
            X1 = X1;
            X2 = X2;
            Y1 = Y1;
            Y2 = Y2;
        }
    }
}