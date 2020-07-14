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

        public AFigure SelectFigureByPoint(Point mousePoint)
        {
            foreach(AFigure a in aFigures)
            {
                //if (a == null)
                //{
                //    continue;
                //}
                //if (a.IsPointInFigure(mousePoint))
                //{
                //    return a;
                //}
                if (a != null)
                {
                    if (a.IsPointInFigure(mousePoint))
                    {
                        return a;
                    }

                }
                
            }
            return null;
        }
    }
}
