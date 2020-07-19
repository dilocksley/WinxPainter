using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Painter
{
    public abstract class StorageFigures
    {

        protected List<AFigure> aFigures = new List<AFigure>();

        public abstract void AddFigure(AFigure aFigure);
        protected AFigure figure;
        public AFigure SelectFigureByPoint(Point mousePoint) // ищщет фигуру, в которой находится мышка (если она есть)
        {
            foreach(AFigure a in aFigures)
            {
                if (a != null)
                {
                    if (a.IsPointInFigure(mousePoint))    // проверяет, находится ли мышка в рамках фигуры
                    {
                        return a;
                    }                    
                }                
            }
            return null;
        }

        public bool SelectFigureByPointq(Point mousePoint) // ищщет фигуру, в которой находится мышка (если она есть)
        {
            foreach (AFigure a in aFigures)
            {
                if (a != null)
                {
                    if (a.IsPointInFigure(mousePoint))    // проверяет, находится ли мышка в рамках фигуры
                    {
                        figure = a;
                        return true;
                    }
                }
            }
            return false;
        }
        public AFigure GetAFigure()
        {
            return figure;
        }
    }
}
