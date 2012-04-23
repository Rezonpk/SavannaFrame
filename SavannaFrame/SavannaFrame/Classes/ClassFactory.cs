using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SavannaFrame.Classes
{
    public static class ClassFactory
    {
        private static KnowLedgeBase KBase = new KnowLedgeBase();
        public static KnowLedgeBase kBase
        {
            get
            {
                return KBase;
            }
        }

        public static string fileName = "";
        public static bool isSaved = true;
        public static int SelectedObjId = -1;

        public static void SaveKBase()
        {
            //FileStream FStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            try
            {
                //делегируем сохранение KnowLedgeBase
                kBase.Save(fileName);
                isSaved = true;
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить в файл!!!", "Ошибка");
            }
            finally
            {
                //if (FStream != null) FStream.Close();
            }
        }

        public static void SaveKBase(string filename)
        {
            fileName = filename;
            SaveKBase();
        }

        public static void LoadKBase(string filename)
        {
            fileName = filename;

            try
            {
                kBase.Load(filename);
                isSaved = true;
            }
            catch
            {
                MessageBox.Show("Транзакционный коллапс!!!!", "Ошибка!!!!");
            }
        }

        public static void NewKnBase()
        {
            KBase = new KnowLedgeBase();
        }
    }
}
