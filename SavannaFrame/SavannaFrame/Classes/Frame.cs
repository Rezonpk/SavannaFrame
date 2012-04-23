using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MS.Internal.Xml.XPath;

namespace SavannaFrame.Classes
{

    /// <summary>
    ///  Класс фреймов
    /// </summary>
    [Serializable]
    public class Frame
    {
        // имя фрейма
        public string FrameName { get; set; }
        // id фрейма
        public int FrameId { get; set; }
        // is_a
        public Slot IsA { get; set; }
        // error
        public Slot Error { get; set; }
        // список слотов фрейма
        public List<Slot> FrameSlots;

        public float X { get; set; }
        public float Y { get; set; }

        public Frame()
        {
            FrameSlots = new List<Slot>();
            //IsA.IsSystem = true;
            //Error.IsSystem = true;
            IsA = new Slot{SlotId = -1, IsSystem = true, SlotName = "IsA", SlotDefault = "NULL", SlotType = SlotType.Frame};
            Error = new Slot { SlotId = -1, IsSystem = true, SlotName = "Error", SlotDefault = "NULL", SlotType = SlotType.Frame };
        }
    }

    [Serializable]
    public class FrameScript : Frame
    {
        // next 
        public Slot Next { get; set; }

        public FrameScript()
        {
            //Next.IsSystem = true;
        }
    }

    /// <summary>
    /// Класс слота фрейма
    /// </summary>
    [Serializable]
    public class Slot
    {
        // ссылка на родителя
        //public Frame Parent { get; set; }
        public int ParentId { get; set; }

        // имя слота
        public string SlotName { get; set; }
        // id слота
        public int SlotId { get; set; }
        // задание отсутствия
        public string SlotDefault { get; set; }
        // тип маркера
        public string SlotMarkerType { get; set; }
        // тип слота 
        public SlotType SlotType { get; set; }
        // вариант наследования 
        public SlotInherit SlotInheritance { get; set; }
        // системный слот
        public bool IsSystem { get; set; }

        //айдишник фрейма в случае, если слот - субфрейм.
        int _frameId = -1;
        public int frameId
        {
            get
            {
                return _frameId;
            }
            set
            {
                this._frameId = value;
            }
        }

        public Slot()
        {
            IsSystem = false;
        }

    }


    public enum SlotType
    {
        Boolean = 0,
        Integer = 1,
        String = 2,
        Frame = 3,
        Production = 5,
        Procedure = 6
    }

    public enum SlotInherit
    {
        Override = 0,
        Unique = 1,
        Same = 2,
        Range = 3
    }


}
