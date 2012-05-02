using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannaFrame.Classes
{
    class MLV
    {
        // Тут типа описание логического вывода для продукций тут вывод непосредственно

        private List<int> checkedFramesIDs = new List<int>();
        FrameExample situationExample = null;

        List<Frame> situations = null;
        List<int> passedSituationsIds = new List<int>();
        List<int> failedSituationsIds = new List<int>();

        /// <summary>
        /// Получает из общего списка фреймов список фреймов-ситуаций (помимо ситуаций в общем списке хранятся так же объекты).
        /// </summary>
        /// <returns></returns>
        List<Frame> gatherSituationsList()
        {
            List<Frame> result = new List<Frame>();
            Dictionary<int, int> inheritanceCount = new Dictionary<int, int>();
            foreach (Frame frame in KnowLedgeBase.Frames)
                if (frame.ContainsSlot("action"))
                {
                    result.Add(frame);
                    inheritanceCount.Add(frame.FrameId, 0);
                }

            foreach (Frame frame in result)
                if (frame.IsA.frameId != -1)
                    inheritanceCount[frame.IsA.frameId] += 1;
            int n = result.Count;
            for (int i = 0; i < n-1; ++i)
                for (int j = i+1; j < n; ++j)
                    if (inheritanceCount[result[i].FrameId] > inheritanceCount[result[j].FrameId])
                    {
                        Frame buf = result[i];
                        result[i] = result[j];
                        result[j] = buf;
                    }
            return result;
        }

        /// <summary>
        /// Выполняет очистку памяти МЛВ (список проверенных фреймов и прочее). 
        /// </summary>
        void clear()
        {
            checkedFramesIDs.Clear();
            passedSituationsIds.Clear();
            failedSituationsIds.Clear();
        }

        /// <summary>
        /// Получает следующий фрейм для привязки.
        /// </summary>
        /// <returns></returns>
        Frame getNextFrameToCheck()
        {
            //TODO: изменить способ выборки
            //Пока просто берет первый попавшийся непроверенный фрейм. Переделать.
            Frame result = null;
            foreach (Frame frame in situations)
                if (!checkedFramesIDs.Contains(frame.FrameId))
                {
                    result = frame;
                    break;
                }
            return result;
        }

        enum Operations
        {
            equal,
            isa,
            notequal,
            lessthan,
            morethan,
            lessequal,
            moreequal
        };

        /// <summary>
        /// Вычисляет выражение, стоящее в левой или правой части condition'а. 
        /// </summary>
        /// <param name="frameContext"></param>
        /// <param name="expression"></param>
        /// <param name="expressionType"></param>
        /// <returns></returns>
        private object evaluateExpression(Frame frameContext, Slot testedSlot, FrameExample frameMemory, FrameExample testedSubFrame, string expression, out SlotType expressionType)
        {
            //object result = null;
            //expressionType = SlotType.String;

            object result = frameMemory;
            expressionType = SlotType.Frame;

            expression = expression.Trim().ToLower();
            int currentIndex = 0;
            string currentPart="";
            while (currentIndex < expression.Length)
            {
                switch (expression[currentIndex])
                {
                    case '[':
                        while (expression[++currentIndex] != ']')
                            currentPart += expression[currentIndex];
                        ++currentIndex;
                        break;
                    case '.':
                        ++currentIndex;
                        continue;
                        break;
                    default:
                        currentPart = expression.Substring(currentIndex);
                        currentPart = currentPart.Replace(" ", "");
                        currentIndex = expression.Length;
                        //обработка всяких там +-1 и т.д.
                        break;
                }
                Slot tmpSlot;
                int tmpInt;
                switch (expressionType)
                {
                    case SlotType.Frame:
                        //tmpSlot = ((FrameExample)result).BaseFrame.GetSlotByName(currentPart);
                        //TODO: костыль ИМХО :(
                        if (currentPart == testedSlot.SlotNameTrimmed)
                            result = testedSubFrame;
                        else
                        {
                            tmpSlot = ((FrameExample)result).GetSlotByName(currentPart);
                            if (tmpSlot.SlotType != SlotType.FramePrototype)
                                result = ((FrameExample)result).Value(currentPart);
                            else
                                result = KnowLedgeBase.getFrameByID(tmpSlot.frameId);
                            expressionType = tmpSlot.SlotType;
                        }
                        break;
                    case SlotType.FramePrototype:
                        //sl = ((Frame)result).GetSlotByName(currentPart);
                        //ничего не надо обрабатывать, ссылка может быть только на сам фрейм-прототип. На его слоты ссылаться мы не можем.
                        break;
                    case SlotType.Integer:
                        tmpInt = Int32.Parse(currentPart);
                        result = ((int)result) + tmpInt;
                        break;
                    case SlotType.Boolean:
                    case SlotType.String:
                        //тоже ничего не будем делать.
                        break;
                }
                currentPart = "";
            }
            return result;
        }

        private bool doesFrameFitCondition(Frame frameContext, FrameExample frameToTest, FrameExample frameMemory, Slot checkedSlot, string condition)
        {
            bool result = false;
            string leftPart=null;
            string rightPart=null;
            Operations operation;
            int operationIndexInText;
            string[] differentOperations = { "#isa", "==", "!=", "#morethan", "#lessthan", "#moreequal", "#lessequal" };
            int operationIndexInArray = -1;
            //foreach (string operationToLookFor in differentOperations)
            for (int i=0; i<differentOperations.Length; ++i)
            {
                string operationToLookFor = differentOperations[i];
                if (condition.Contains(operationToLookFor))
                {
                    operationIndexInText = condition.IndexOf(operationToLookFor);
                    operationIndexInArray = i;
                    leftPart = condition.Substring(0, operationIndexInText);
                    rightPart = condition.Substring(operationIndexInText + operationToLookFor.Length);
                    break;
                }
            }
            switch (operationIndexInArray)
            {
                case 0:
                    operation = Operations.isa;
                    break;
                case 1:
                    operation = Operations.equal;
                    break;
                case 2:
                    operation = Operations.notequal;
                    break;
                case 3:
                    operation = Operations.morethan;
                    break;
                case 4:
                    operation = Operations.lessthan;
                    break;
                case 5:
                    operation = Operations.moreequal;
                    break;
                case 6:
                    operation = Operations.lessequal;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
            SlotType leftType, rightType;
            object leftPartResult = evaluateExpression(frameContext, checkedSlot, frameMemory, frameToTest, leftPart, out leftType);
            object rightPartResult = evaluateExpression(frameContext, checkedSlot, frameMemory, frameToTest, rightPart, out rightType);

            Exception typeComparisonException = new Exception("Can not compare different types!");

            switch (operation)
            {
                case Operations.isa:
                    if (leftType == SlotType.Frame && rightType == SlotType.FramePrototype)
                    {
                        result = ((FrameExample)leftPartResult).CheckIsA((Frame)rightPartResult);
                    }
                    else
                        throw new Exception("Incorrect frame types for 'is a' relation!");
                    break;
                case Operations.equal:
                    if (leftType == rightType)
                    {
                        switch (leftType)
                        {
                            //TODO: возможно, тут стоит добавить более изящное сравнение.
                            case SlotType.Boolean:
                                result = leftPartResult.ToString() == rightPartResult.ToString();
                                break;
                            case SlotType.Integer:
                                result = ((int)leftPartResult) == ((int)rightPartResult);
                                break;
                            case SlotType.String:
                                result = leftPartResult.ToString() == rightPartResult.ToString();
                                break;
                            default:
                                throw new Exception("Only boolean, integer and string slots can be compared.");
                        }
                    }
                    else
                        throw typeComparisonException;
                    break;
                case Operations.notequal:
                    if (leftType == rightType)
                    {
                        result = leftPartResult.ToString() == rightPartResult.ToString();
                    }
                    else
                        throw typeComparisonException;
                    break;
                case Operations.morethan:
                    if (leftType == rightType && rightType == SlotType.Integer)
                    {
                        result = ((int)leftPartResult) > ((int)rightPartResult);
                    }
                    else
                        throw typeComparisonException;
                    break;
                case Operations.lessthan:
                    if (leftType == rightType && rightType == SlotType.Integer)
                    {
                        result = ((int)leftPartResult) < ((int)rightPartResult);
                    }
                    else
                        throw typeComparisonException;
                    break;
                case Operations.moreequal:
                    if (leftType == rightType && rightType == SlotType.Integer)
                    {
                        result = ((int)leftPartResult) >= ((int)rightPartResult);
                    }
                    else
                        throw typeComparisonException;
                    break;
                case Operations.lessequal:
                    if (leftType == rightType && rightType == SlotType.Integer)
                    {
                        result = ((int)leftPartResult) <= ((int)rightPartResult);
                    }
                    else
                        throw typeComparisonException;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Привязываем субфрейм.
        /// </summary>
        /// <param name="frameTested"></param>
        /// <param name="marker"></param>
        /// <returns></returns>
        private FrameExample boundSubframe(Slot slot, FrameExample situationExample)
        {
            FrameExample result = null;
            Frame framePrototype = KnowLedgeBase.getFrameByID(slot.frameId);
            List<FrameExample> framesCandidates = new List<FrameExample>();
            foreach (FrameExample frame in KnowLedgeBase.FramesExamples)
                if (frame.CheckIsA(framePrototype))
                    framesCandidates.Add(frame);

            string[] separatorsOr = { "#or" };
            string[] separatorsAnd = { "#and" };
            foreach (FrameExample candidate in framesCandidates)
            {                
                string[] conjuncts = slot.SlotMarker.Split(separatorsOr, StringSplitOptions.None);
                foreach (string conjunct in conjuncts)
                {
                    string[] conditions = conjunct.Split(separatorsAnd, StringSplitOptions.None);
                    bool fitsAllConditions = true;
                    foreach (string condition in conditions)
                    {
                        if (!doesFrameFitCondition(framePrototype, candidate, situationExample, slot, condition))
                        {
                            fitsAllConditions = false;
                            break;
                        }
                    }
                    if (fitsAllConditions)
                    {
                        result = candidate;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Привязываем слот (проверяем на соответствие маркеру)
        /// </summary>
        /// <param name="slot">Сам слот</param>
        /// <param name="situationProrotype">Ситуация, которую мы сейчас привязываем (см. checkSituation).</param>
        /// <param name="situationExample">Текущий фрейм-экземпляр.</param>
        /// <returns>Если слот привязался, возвращаем его значение (в соответствие с типом слота). Иначе - null.</returns>
        private object boundSlot(Slot slot, Frame situationProrotype, FrameExample situationExample)
        {
            object result = null;
            switch (slot.SlotType)
            {
                case SlotType.Frame:
                    FrameExample boundedSubframe = boundSubframe(slot, situationExample);
                    result = boundedSubframe;
                    break;
                //сколько тут получилось разнообразных вариантов вывода, аж обалдеть можно. 
            }
            return result;
        }

        /// <summary>
        /// Попробовать привязаться к конкретной ситуации
        /// </summary>
        /// <param name="situationPrototype">Ситуация, к которой мы хотим привязаться (которую мы проверяем)</param>
        /// <param name="situationExample">Текущий фрейм-экземпляр</param>
        /// <returns>true - если привязалась. false - в противном случае.</returns>
        private bool checkSituation(Frame situationPrototype, FrameExample situationExample)
        {
            bool result = true;
            List<Slot> boundedSlots = new List<Slot>(); //привязавшиеся слоты
            Dictionary<string, object> slotValues=new Dictionary<string, object>(); //значения привязавшихся слотов

            foreach (Slot slot in situationPrototype.FrameSlots)
            {
                if (slot.SlotMarker != null)
                {
                    object slotValue;

//                    if (situationExample.ContainsSlot(slot.SlotName))
//                        slotValue = situationExample.Value(slot.SlotName);
//                    else
                    if (!situationExample.ContainsSlot(slot.SlotName))
                    {
                        slotValue = boundSlot(slot, situationPrototype, situationExample);

                        if (slotValue == null)
                        {
                            result = false;
                            break;
                        }
                        else
                        {
                            boundedSlots.Add(slot);
                            slotValues.Add(slot.SlotNameTrimmed, slotValue);
                        }
                    }
                }
            }

            if (result)
            {
                //TODO:                 
                //тут еще как-то, думаю, будут использоваться задания отсутствия
                //плюс, возможно, нужно будет добпвлять не только привязавшиеся слоты, но и вообще все.
                foreach (Slot boundedSlot in boundedSlots)
                {
                    situationExample.AddSlot(boundedSlot);
                    situationExample.SetValue(boundedSlot.SlotName, slotValues[boundedSlot.SlotNameTrimmed]); 
                }
            }
            return result;
        }

        public object doMLVForPoint(GameCell gameCell)
        {
            object result="Клетка пуста.";
            if (gameCell.FrameExample != null && gameCell.FrameExample.BaseFrame != null && gameCell.FrameExample.BaseFrame.FrameId != -1)
            {
                situations = gatherSituationsList();

                situationExample = new FrameExample();
                Slot slotAgent = new Slot();
                slotAgent.SlotName = "agent";
                slotAgent.SlotType = SlotType.Frame;
                slotAgent.SlotInheritance = SlotInherit.Override;
                slotAgent.IsSystem = false;
                situationExample.AddSlot(slotAgent);
                situationExample.SetValue("agent", gameCell.FrameExample);
                Frame situationToCheck = this.getNextFrameToCheck();

                while (!situationExample.ContainsSlot("action") && situationToCheck != null) //пока не определили целевой слот "действие"
                {
                    checkedFramesIDs.Add(situationToCheck.FrameId);
                    if (checkSituation(situationToCheck, situationExample))
                    {
                        Slot actionSlot = situationToCheck.GetSlotByName("action");
                        situationExample.AddSlot(actionSlot);
                        situationExample.SetValue(actionSlot.SlotName, actionSlot.SlotDefault);
                        passedSituationsIds.Add(situationToCheck.FrameId);
                    }
                    else
                        failedSituationsIds.Add(situationToCheck.FrameId);
                    situationToCheck = this.getNextFrameToCheck();
                }
                result = null;
                if (situationExample.ContainsSlot("action"))
                    result = situationExample.Value("action");
            }
            return result;
        }
    }
}