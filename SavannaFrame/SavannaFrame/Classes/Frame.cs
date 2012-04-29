using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MS.Internal.Xml.XPath;
using System.Collections;

namespace SavannaFrame.Classes
{

    /// <summary>
    ///  Класс фреймов
    /// </summary>
    [Serializable]
    public class Frame
    {

        string frameName;
        // имя фрейма
        public string FrameName { 
            get
            {
                return this.frameName;
            }
            set
            {
                frameName = value;
            }
        }

        public string FrameNameTrimmed
        {
            get
            {
                return this.frameName.Trim().ToLower();
            }
        }
        // id фрейма
        public int FrameId { get; set; }
        // is_a
        public Slot IsA { get; set; }
        // error
        public Slot Error { get; set; }
        // список слотов фрейма

        public Frame GetParentFrame()
        {
            return KnowLedgeBase.getFrameByID(this.IsA.frameId);
        }

        public List<Slot> FrameSlots;

        //public List<Slot> AllSlots()
        //{
        //    List<Slot> result = new List<Slot>();
        //    Frame parent = KnowLedgeBase.getFrameByID(this.IsA.frameId);
        //    if (parent != null)
        //        result.AddRange(parent.AllSlots());
        //    foreach (Slot slot in this.FrameSlots)
        //    {
        //        switch (slot.SlotInheritance)
        //        {
        //            case SlotInherit.Same:
        //                if (
        //                break;
        //        }
        //    }

        //    return result;
        //}

        private object GetSlotDefaultValuePrivate(string slotNameTrimmed)
        {
            // Frames.Find(f => f.FrameId == frameID);
            object result=null;
            Slot slot = FrameSlots.Find(s => (s.SlotNameTrimmed.Length == slotNameTrimmed.Length && s.SlotNameTrimmed == slotNameTrimmed));
            if (slot != null)
                return slot.SlotDefault;
            else
            {
                Frame parentFrame = this.GetParentFrame();
                if (parentFrame !=null)
                    result = parentFrame.GetSlotDefaultValuePrivate(slotNameTrimmed);
            }
            return result;
        }

        public object GetSlotDefaultValue(string slotName)
        {
            return this.GetSlotDefaultValuePrivate(slotName.Trim().ToLower());
        }

        /// <summary>
        /// Координата X фрейма НА ДИАГРАММЕ
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Координата Y фрейма НА ДИАГРАММЕ
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Проверяет, содаржит ли данный фрейм слот с заданным именем. Для имени выполняется toLower()+trim().
        /// </summary>
        /// <param name="slotName"></param>
        /// <returns></returns>
        public bool ContainsSlot(String slotName)
        {
            bool result = false;
            slotName = slotName.Trim().ToLower();
            foreach (Slot slot in this.FrameSlots)
            {
                if (slot.SlotNameTrimmed.Length == slotName.Length && slot.SlotNameTrimmed == slotName)
                {
                    result = true;
                    break;
                }
            }
            if (!result)
            {
                Frame parentFrame = this.GetParentFrame();
                if (parentFrame != null)
                    result = parentFrame.ContainsSlot(slotName);
            }
            return result;
        }

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

    public class FrameExample
    {
        /// <summary>
        /// Значения слотов <имя слота, значение>.
        /// </summary>
        Dictionary<String, object> values = new Dictionary<string,object>();

        private bool containsSlotPrivate(string slotNameTrimmed)
        {
            bool result = false;
            foreach (Slot slotOwn in this.slots)
                if (slotOwn.SlotNameTrimmed.Length == slotNameTrimmed.Length && slotOwn.SlotNameTrimmed == slotNameTrimmed)
                {
                    result = true;
                    break;
                }
            if (!result && BaseFrame != null)
                result = BaseFrame.ContainsSlot(slotNameTrimmed);
            return result;
        }

        public bool ContainsSlot(string slotName)
        {
            slotName = slotName.Trim().ToLower();
            return this.containsSlotPrivate(slotName);
        }
        

        public object Value(String slotName)
        {
            object value = null;
            slotName = slotName.Trim().ToLower();
            //if (this.BaseFrame != null)
            //{
            //    if (BaseFrame.ContainsSlot(slotName))
            //    {
            //        slotName = slotName.Trim().ToLower();
            //        if (values.ContainsKey(slotName))
            //            value = values[slotName];
            //        else
            //            value = BaseFrame.GetSlotDefaultValue(slotName);
            //    }
            //    else
            //        throw new KeyNotFoundException("Родительский фрейм " + BaseFrame.FrameName + " не содержит слота с именем " + slotName);
            //}
            //else
            //    if (values.ContainsKey(slotName))
            //        value = values[slotName];
            if (this.containsSlotPrivate(slotName))
                value = values[slotName];
            else
                throw new KeyNotFoundException("Слот "+slotName+" не найден как во фрейме-экземпляре, так и в родительском фрейме.");
            return value;
        }

        public void SetValue(String slotName, object value)
        {
            slotName = slotName.Trim().ToLower();
            //if (BaseFrame != null)
            //{
            //    if (BaseFrame.ContainsSlot(slotName))
            //        values.Add(slotName, value);
            //    else
            //        throw new KeyNotFoundException("Родительский фрейм " + BaseFrame.FrameName + " не содержит слота с именем " + slotName);
            //}
            //else
            //    values.Add(slotName, value);
            
            //if (values.ContainsKey(slotName) || (BaseFrame != null && BaseFrame.ContainsSlot(slotName)))
            if (this.containsSlotPrivate(slotName))
            {
                if (values.ContainsKey(slotName))
                    values[slotName] = value;
                else
                    values.Add(slotName, value);
            }
        }

        public void AddSlot(Slot slot)
        {
            if (!this.ContainsSlot(slot.SlotName))
                this.slots.Add(slot);
            else
                throw new ArgumentException("Слот с таким именем ("+slot.SlotName+") уже существует");
        }

        Frame baseFrame;

        public Frame BaseFrame
        {
            private set
            {
                this.baseFrame = value;
            }
            get 
            {
                return this.baseFrame;
            }
        }

        private List<Slot> slots = new List<Slot>();
        public List<Slot> Slots
        {
            get { return this.slots; }
            set { slots = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseFrame">ссылка на фрейм-прототип. НЕ может быть null</param>
        public FrameExample(Frame inputBaseFrame=null)
        {
            this.BaseFrame = inputBaseFrame;
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

        string slotName;
        // Получает или задает имя слота
        public string SlotName
        {
            get
            {
                return this.slotName;
            }
            set
            {
                this.slotName = value;
            }
        }

        /// <summary>
        /// Получает имя слота + toLower() + trim()
        /// </summary>
        public string SlotNameTrimmed
        {
            get
            {
                return this.slotName.Trim().ToLower();
            }
        }

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
